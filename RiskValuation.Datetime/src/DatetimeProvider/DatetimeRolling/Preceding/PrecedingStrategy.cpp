#include "PrecedingStrategy.h"

PrecedingStrategy::PrecedingStrategy(int year, unsigned month, unsigned day) :
	IRollingStrategy{}, year_{year} , month_{month}, day_{day}{}

ChronoDate PrecedingStrategy::DayRolling() {
	auto date = DateUtility::YearMonthDate(year_, month_, day_);
	constexpr int flooringDay = 5; // block to friday 
	int dayOfWeek = DateUtility::DaysOfWeek(date);

	auto adjustedSerialDate = std::chrono::sys_days(date) - std::chrono::days(dayOfWeek - flooringDay);
	date = std::chrono::year_month_day{ adjustedSerialDate };
	return date;
}