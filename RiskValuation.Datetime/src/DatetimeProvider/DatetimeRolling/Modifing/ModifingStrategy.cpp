#include "ModifingStrategy.h"
#include "../../DatetimeUtility/SharedDatetime.h"


ModifingStrategy::ModifingStrategy(int year, unsigned month, unsigned day) :
	IRollingStrategy(), year_(year), month_(month), day_(day) {};

ChronoDate ModifingStrategy::DayRolling() {
	constexpr int ceilingDay = 8;
	auto date = DateUtility::YearMonthDate(year_, month_, day_);
	int dayOfWeek = DateUtility::DaysOfWeek(date); // change this function to local
	constexpr int flooringDay = 3;
	
	auto originalMonth = static_cast<unsigned>(date.month());
	auto adjustedSerialDate = std::chrono::sys_days(date) + std::chrono::days(ceilingDay - dayOfWeek); // temp to forward date ;

	date = std::chrono::year_month_day{adjustedSerialDate };

	// rolling for week-end ; three day back 
	if ( auto value = static_cast<unsigned> (date.month()) ; value > originalMonth){ // rollback to friday ; feature Cpp17
		adjustedSerialDate = std::chrono::sys_days(date) - std::chrono::days(flooringDay);
		return std::chrono::year_month_day{ adjustedSerialDate };
	}
	return date;
}