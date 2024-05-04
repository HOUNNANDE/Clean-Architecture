#include "SharedDatetime.h"
#include <array>
#include <utility>

namespace DateUtility {

	ChronoDate ChronoDatetime(int year, unsigned month, unsigned day) {
		return std::chrono::year_month_day{ std::chrono::year(year), std::chrono::month{month}, std::chrono::day {day} };
	}

	bool isValideDate(ChronoDate const& date) {

		return (date.ok() )? true : false; 
	}

	bool isLeapYear(ChronoDate const& date) {
		std::chrono::year year {date.year()};
		return ((year.is_leap())) ? true : false;
	}

	unsigned EndOfMonth(ChronoDate const& date) {
		constexpr std::array <int, 12> endOfMonthCommon = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		auto dateMonth = static_cast<unsigned>(date.month());

			if (auto isleapyear = (date.year()).is_leap(); //cpp17 feature;
				dateMonth == 2 && isleapyear) { 
			return 29; // leap year for february ; 
		}
		return endOfMonthCommon[dateMonth - 1];
	}

	int SerialDate(ChronoDate const& date) {
		return static_cast<int>(std::chrono::sys_days(date).time_since_epoch().count());
	}
	ChronoDate& YearMonthDate(int year, unsigned month, unsigned day) {
		ChronoDate date {std::chrono::year(year), std::chrono::month{month}, std::chrono::day{day} }; 
		return date;
	}
	int DaysOfWeek(ChronoDate const & datetime){
		auto dayOfWeek = WKDay{ std::chrono::sys_days(datetime) };
		return dayOfWeek.iso_encoding();
	}
}
