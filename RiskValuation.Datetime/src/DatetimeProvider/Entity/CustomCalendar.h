#pragma once
#include<chrono>

using ymd = std::chrono::year_month_day; 
struct CustomCalendar {
	CustomCalendar(int year, unsigned month, unsigned day); 
	
	ymd yearMonthDate_{}; 
};
