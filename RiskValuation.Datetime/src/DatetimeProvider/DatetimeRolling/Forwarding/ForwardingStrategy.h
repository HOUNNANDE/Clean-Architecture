#pragma once
#include "../Interfaces/DayRollingStrategy.h"
class ForwardingStrategy :public IRollingStrategy {
	
public:
	ForwardingStrategy (int year, unsigned month, unsigned day);
	ChronoDate DayRolling() override;
private:
	int year_;
	unsigned month_;
	unsigned day_;
};

 