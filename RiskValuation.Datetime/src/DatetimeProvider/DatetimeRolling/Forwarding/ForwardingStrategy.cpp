#include "ForwardingStrategy.h"
#include "../../DatetimeUtility/SharedDatetime.h"

ForwardingStrategy::ForwardingStrategy(int year, unsigned month, unsigned day) :
	IRollingStrategy(), year_(year), month_(month), day_(day) {}

ChronoDate ForwardingStrategy::DayRolling() {
	auto date = DateUtility::YearMonthDate(year_, month_, day_);
	constexpr int ceilingDay = 8; // number of day from monday to monday 
	int dayOfWeek = DateUtility::DaysOfWeek(date);
	auto adjustedSerialDate = std::chrono::sys_days(date) + std::chrono::days(ceilingDay - dayOfWeek); // add number of day to get monday

	return  std::chrono::year_month_day{ adjustedSerialDate };
}