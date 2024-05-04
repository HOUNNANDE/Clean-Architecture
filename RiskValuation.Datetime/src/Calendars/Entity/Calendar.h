#pragma once
#include <string>
struct Calendar
{
	Calendar(int targetDay, int targetMonth, int year, std::string const& description, std::string const &type);

	int targetDay_;
	int targetMonth_;
	int targetYear_;
	std::string targetDescription_;
	std::string targetCalendarType_;
};

