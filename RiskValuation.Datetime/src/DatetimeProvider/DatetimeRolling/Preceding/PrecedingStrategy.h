#pragma once
#include "../Forwarding/ForwardingStrategy.h"
#include "../../DatetimeUtility/SharedDatetime.h"

class PrecedingStrategy : public IRollingStrategy
{
public:
	PrecedingStrategy(int year, unsigned month, unsigned day);
	ChronoDate DayRolling() override;
private:
	int year_;
	unsigned month_;
	unsigned day_;
};


