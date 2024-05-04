#pragma once
#include <chrono>

using ChronoDate = std::chrono::year_month_day; 

class IRollingStrategy {

public: 
	IRollingStrategy() = default; 
	virtual ~IRollingStrategy(); 
	virtual ChronoDate DayRolling() = 0;
protected: 
	IRollingStrategy(IRollingStrategy const&) = default; 
	IRollingStrategy& operator = (IRollingStrategy const&) = default;
	IRollingStrategy(IRollingStrategy&&) = default;
	IRollingStrategy& operator = (IRollingStrategy&&) = default; 
};