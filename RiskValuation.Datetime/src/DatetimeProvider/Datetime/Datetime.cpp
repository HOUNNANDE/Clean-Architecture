#include "Datetime.h"
#include "../DatetimeUtility/SharedDatetime.h"
#include <array>
#include <utility>
#include <ranges>
#include <execution>


 DatetimeProvider::DatetimeProvider(int year, unsigned month, unsigned day) :
	year_{ year }, month_{ month }, day_{ day }{
	ChronoDate date_(std::chrono::year{year_}, std::chrono::month{month_}, std::chrono::day{day_}); 

	if (!date_.ok()) {
		std::exception InvalideDateConstructor("invalide date construction");
		throw InvalideDateConstructor;
    }
};
 // default date based on POSIX default system date; 

 DatetimeProvider::DatetimeProvider() : year_{ std::chrono::year{1970} }, month_{ std::chrono::month{1} }, day_{ std::chrono::day{1}} {}

 bool DatetimeProvider::isValideDate() const noexcept {
	ChronoDate date_{DateUtility::YearMonthDate(year_, month_, day_)};

	return (date_.ok()) ? true : false; 
}

 bool DatetimeProvider::isLeapYear() const noexcept {
	std::chrono::year year {year_};
	return (year.is_leap()) ? true : false; 
}

 unsigned DatetimeProvider::EndOfMonth() const noexcept {
	constexpr std::array <int, 12> endOfMonthCommon = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; // end months 

	if (auto isleap = isLeapYear(); month_ == 2 && isleap) { // cpp 17 feature
		return 29; // leap year for february ; 
	}
	return endOfMonthCommon[month_ - 1];
}

 constexpr int DatetimeProvider::Year() const noexcept{
	return year_;
}

constexpr unsigned DatetimeProvider::Month() const noexcept{
	return month_;
}

constexpr unsigned DatetimeProvider::Day() const noexcept {
	return day_;
}

int DatetimeProvider::SerialDate() const  {
ChronoDate date_{ DateUtility::YearMonthDate(year_, month_, day_) };
return static_cast<int>(std::chrono::sys_days(date_).time_since_epoch().count());
}

// define internal mapping ; 
DatetimeProvider & DatetimeProvider::DateMapper(ChronoDate&& date) {
	year_ = static_cast<int>(date.year());
	month_ = static_cast<unsigned>(date.month());
	day_ = static_cast<unsigned>(date.day());
	return (*this);
}

std::strong_ordering DatetimeProvider::operator <=> (DatetimeProvider const& datetime) const {
	ChronoDate date_{ DateUtility::YearMonthDate(year_, month_, day_) };
	ChronoDate otherdate_{ DateUtility::YearMonthDate(datetime.year_, datetime.month_, datetime.day_) };

	auto _comp = date_.year() <=> otherdate_.year();
	if (_comp != 0) {
		return _comp;
	}
	auto comp_ = date_.month() <=> otherdate_.month();
	if (comp_ != 0) {
		return comp_;
	}
	return date_.day() <=> otherdate_.day();
}

bool DatetimeProvider::operator==(DatetimeProvider const& datetime) const{
	ChronoDate date_(DateUtility::YearMonthDate(year_, month_, day_));
	ChronoDate otherdate_(DateUtility::YearMonthDate(datetime.year_, datetime.month_, datetime.day_));
	
	return date_.year() == otherdate_.year() && date_.month() == otherdate_.month() && date_.day() == otherdate_.day();
}

 unsigned DatetimeProvider::DaysOfWeek()const {
	ChronoDate date_(DateUtility::YearMonthDate(year_, month_, day_));
	auto dayOfWeek = WKDay{ std::chrono::sys_days(date_) };
	return dayOfWeek.iso_encoding();
}

DatetimeProvider& DatetimeProvider::AddDays(int numberOfDays) {
	using ChronoDate = std::chrono::year_month_day;
	ChronoDate date_(std::chrono::year{year_}, std::chrono::month{month_}, std::chrono::day{day_});
	
	std::chrono::sys_days dateToSysDays = std::chrono::sys_days(date_) + std::chrono::days(numberOfDays);
	date_ = std::chrono::year_month_day{ dateToSysDays };

	return DateMapper(std::move(date_)); 
}

DatetimeProvider& DatetimeProvider::AddYears(int numberOfYears) {
	if (numberOfYears < 0) {
		std::logic_error AddingNegativeYear("negative year"); 
		throw AddingNegativeYear; 
	}
	year_  += numberOfYears;
	return *this; 
}

DatetimeProvider & DatetimeProvider::AddMonths(int numberOfMonths) {
	using Ymd = std::chrono::year_month_day;

	ChronoDate date_(DateUtility::YearMonthDate(year_, month_, day_));
	date_ = date_ + std::chrono::months(numberOfMonths);

	if (!date_.ok()) {
		auto lastDayinMonth = DateUtility::EndOfMonth(date_);
		date_ = std::chrono::year_month_day{
		std::chrono::year {date_.year()}, std::chrono::month{date_.month()}, std::chrono::day{lastDayinMonth} };
		return DateMapper(std::move(date_)); 
	}
	return DateMapper(std::move(date_));
}

 unsigned DatetimeProvider::DaysBetween(DatetimeProvider const & otherDatetime) const {

	using ChronoDate = std::chrono::year_month_day;
	using Sys_Day = std::chrono::sys_days; 

	ChronoDate date_(DateUtility::YearMonthDate(year_, month_, day_));
	ChronoDate otherdate_(DateUtility::YearMonthDate(otherDatetime.year_, otherDatetime.month_, otherDatetime.day_));
	
	// other date is supposed to be the less of the two ; 

	if (date_ < otherdate_) {
		std::logic_error DatetimeError ("start date is greater than the end date");
		throw DatetimeError; 
	}
	auto dateDiff = (Sys_Day(date_) - Sys_Day(otherdate_)).count(); 
	return dateDiff; 
}

bool DatetimeProvider::isWeekend() const {
	int dayOfWeek = DaysOfWeek(); 
	return (dayOfWeek > 5) ? true : false; 
}

bool DatetimeProvider::isHoliday(std::shared_ptr<ITargetCalendarFactory> targetCalendar) const
{
	using SharedCalendar = std::shared_ptr<ITargetCalendarFactory>; 

	SharedCalendar targetCalendar_{std::move(targetCalendar) };

	std::vector<CustomCalendar> sharedTargetCalendar = (*targetCalendar_).LoadCalendarAsync(); 

	ChronoDate date_(DateUtility::YearMonthDate(year_, month_, day_));

	auto holidayItr = std::ranges::find_if(sharedTargetCalendar, [date = std::move(date_)](auto const& value) { // capture only date by reference
		return value.yearMonthDate_ == date;
		});

	return (holidayItr == std::cend(sharedTargetCalendar) ? false : true);
}


 bool DatetimeProvider::isBusinessDay(std::shared_ptr<ITargetCalendarFactory> targetCalendar) const {
	auto isInWeekEnd = isWeekend(); 
	auto isInHoliday = isHoliday(targetCalendar);
	auto isWorkingDay = (isInWeekEnd == false && isInHoliday == false) ? true : false; 
	
	return isWorkingDay; 
}

 std::vector<CustomCalendar> DatetimeProvider::Holidays(std::shared_ptr<ITargetCalendarFactory> targetCalendar,
	 DatetimeProvider from, DatetimeProvider to) {

	 using ChronoDate = std::chrono::year_month_day; 
	 auto targetCalendar_ = std::move(targetCalendar);
	 std::vector<CustomCalendar> calendar = (*targetCalendar_).LoadCalendarAsync(); 
	 std::vector<CustomCalendar> holidays{};  // initit empty vector to hold holidays
	 
	 auto fromDate = DateUtility::YearMonthDate(from.year_, from.month_, from.day_); 
	 auto toDate = DateUtility::YearMonthDate(to.year_, to.month_, to.day_);
	 
	 std::mutex mlock;
	 std::for_each(std::execution::par, std::cbegin(calendar), std::cend(calendar),
		 [&](auto const & value) {
			 auto isCountable =  value.yearMonthDate_ > fromDate && value.yearMonthDate_ < toDate ;
			 if (isCountable)
			 {
				 std::scoped_lock<std::mutex> lockGuard(mlock);
				 holidays.emplace_back(std::move(value));
			 };
		 });
	 return holidays;
 }

 // no more used 
 DatetimeProvider& DatetimeProvider::AdjustDateWeekEnd2(DateRollingOptions rollingOption) {

	 if (isWeekend()) {
		 switch (rollingOption)
		 {
			 case DateRollingOptions::preciding: { // preceding rolling  date minus 3 days
				 auto date = DateUtility::YearMonthDate(year_, month_, day_);
				 constexpr int flooringDay = 3;
				 auto adjustedSerialDate = std::chrono::sys_days(date) - std::chrono::days(flooringDay);
				 date = std::chrono::year_month_day{ adjustedSerialDate };

				 year_ = static_cast<int>(date.year());
				 month_ = static_cast<unsigned>(date.month());
				 day_ = static_cast<unsigned>(date.day());
				 return (*this);
			 }
			case DateRollingOptions::forwarding: {
				constexpr int ceilingDay = 8;
				auto date = DateUtility::YearMonthDate(year_, month_, day_);
				int dayOfWeek = static_cast<int>(DaysOfWeek());

				auto adjustedSerialDate = std::chrono::sys_days(date) + std::chrono::days(ceilingDay - dayOfWeek);
				date = std::chrono::year_month_day{ adjustedSerialDate };

				year_ = static_cast<int>(date.year());
				month_ = static_cast<unsigned>(date.month());
				day_ = static_cast<unsigned>(date.day());
				return (*this);
			}

			 case DateRollingOptions::modifing: {  // modifing following: forward rolling and if not define then rollbackward
				 constexpr int ceilingDay = 8;
				 auto date = DateUtility::YearMonthDate(year_, month_, day_);
				 int dayOfWeek = static_cast<int>(DaysOfWeek());
				 constexpr int flooringDay = 3;

				 auto originalMonth = static_cast<unsigned>(date.month());
				 auto adjustedSerialDate = std::chrono::sys_days(date) + std::chrono::days(ceilingDay - dayOfWeek);
				 date = std::chrono::year_month_day{ adjustedSerialDate };

				 // rolling for week-end ; three day back 
				 if (static_cast<unsigned>(date.month()) > originalMonth) {
					 adjustedSerialDate = std::chrono::sys_days(date) - std::chrono::days(flooringDay);
					 date = std::chrono::year_month_day{ adjustedSerialDate };

					 year_ = static_cast<int>(date.year());
					 month_ = static_cast<unsigned>(date.month());
					 day_ = static_cast<unsigned>(date.day());
					 return (*this);
				 }
				 year_ = static_cast<int>(date.year());
				 month_ = static_cast<unsigned>(date.month());
				 day_ = static_cast<unsigned>(date.day());
				 return (*this);
			 }
		 }
		 return (*this);
	 }
	 return (*this);
 }

 // simplified version of weekend adjustment
 DatetimeProvider& DatetimeProvider::AdjustDateWeekEnd(IRollingStrategy & rollingStrategy) {
	 // convert date to datetimeprovider format 
	 if (isWeekend()) {
		 return DateMapper(std::move(rollingStrategy.DayRolling()));
	 }
	 return (*this); // return if not weekend
 }
 
 DatetimeProvider& DatetimeProvider::AdjustDateHoliday(std::shared_ptr<ITargetCalendarFactory> targetCalendar, 
	 DateRollingOptions rollingOption) {

	 while(isHoliday(std::move(targetCalendar))) {

		 switch (rollingOption)
		 {
			 case DateRollingOptions::preciding: {
				 auto date = DateUtility::YearMonthDate(year_, month_, day_);

				 constexpr int mooveDay = 1;
				 auto adjustedSerialDate = std::chrono::sys_days(date) - std::chrono::days(mooveDay);
				 date = std::chrono::year_month_day{ adjustedSerialDate };

				 year_ = static_cast<int>(date.year());
				 month_ = static_cast<unsigned>(date.month());
				 day_ = static_cast<unsigned>(date.day());
				 
				 return (*this);

			 }
			 case DateRollingOptions::forwarding: {
				 auto date = DateUtility::YearMonthDate(year_, month_, day_);

				 constexpr int mooveDay = 1;
				 auto adjustedSerialDate = std::chrono::sys_days(date) + std::chrono::days(mooveDay);
				 date = std::chrono::year_month_day{ adjustedSerialDate };

				 year_ = static_cast<int>(date.year());
				 month_ = static_cast<unsigned>(date.month());
				 day_ = static_cast<unsigned>(date.day());
				 return (*this);
			 }
			 case DateRollingOptions::modifing: {
				 auto date = DateUtility::YearMonthDate(year_, month_, day_);
				 auto originalMonth = static_cast<unsigned> (date.month()); 

				 constexpr int mooveDay = 1;
				 auto adjustedSerialDate = std::chrono::sys_days(date) + std::chrono::days(mooveDay);
				 date = std::chrono::year_month_day{ adjustedSerialDate }; 

				 // rolling for week-end ; three day back 
				 if (static_cast<unsigned>(date.month()) > originalMonth) {
					 adjustedSerialDate = std::chrono::sys_days(date) - std::chrono::days(mooveDay);
					 date = std::chrono::year_month_day{ adjustedSerialDate };

					 year_ = static_cast<int>(date.year());
					 month_ = static_cast<unsigned>(date.month());
					 day_ = static_cast<unsigned>(date.day());
					 return (*this);
				 }
				 year_ = static_cast<int>(date.year());
				 month_ = static_cast<unsigned>(date.month());
				 day_ = static_cast<unsigned>(date.day());
				 return (*this);
			 } 
		 }
		 return (*this);
	 }
	 return (*this);
 }



