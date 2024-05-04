#pragma once
#include <chrono>
#include"../Enum/RollingOptions.h"

using WKDay = std::chrono::weekday; // shortCut day of week 
namespace DateUtility {

	using ChronoDate = std::chrono::year_month_day;

	ChronoDate ChronoDatetime(int year, unsigned month, unsigned day);

	bool isLeapYear(ChronoDate const& date);
	bool isValideDate(ChronoDate const& date);

	unsigned EndOfMonth(ChronoDate const& date);

	int SerialDate(ChronoDate const& date);

	ChronoDate& YearMonthDate(int year, unsigned month, unsigned day);
	int DaysOfWeek(const ChronoDate &);

	

	

}



