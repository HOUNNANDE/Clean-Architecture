#pragma once
#include "../Interfaces/DayRollingStrategy.h"

using WKDay = std::chrono::weekday; // shortCut day of week 
class ModifingStrategy: public IRollingStrategy 
{
public:
	ModifingStrategy (int year, unsigned month, unsigned day);
    ChronoDate DayRolling() override ;

private:
	int year_;
	unsigned month_;
	unsigned day_;
};

