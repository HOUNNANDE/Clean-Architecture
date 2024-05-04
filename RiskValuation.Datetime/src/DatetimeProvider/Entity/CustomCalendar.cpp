#include "CustomCalendar.h"

CustomCalendar::CustomCalendar(int year, unsigned month, unsigned day) :
	yearMonthDate_{ std::chrono::year(year), std::chrono::month(month), std::chrono::day(day) } {};