#pragma once
#include "../RiskValuation.Application/RiskValuation.Datetime/src/Calendars/TargetCalendarDeserializer/Interfaces/ICalendarDeserializer.h"
#include "../../../DatetimeProvider/Entity/CustomCalendar.h"

class ITargetCalendarFactory
{
public:
	ITargetCalendarFactory() {};
	virtual std::vector<CustomCalendar> LoadCalendarAsync() = 0;
	virtual ~ITargetCalendarFactory() {};
protected:
	ITargetCalendarFactory(ITargetCalendarFactory const&) = default; 
	ITargetCalendarFactory& operator = (ITargetCalendarFactory const&) = default; 
	ITargetCalendarFactory(ITargetCalendarFactory&&) = default; 
	ITargetCalendarFactory& operator = (ITargetCalendarFactory&&) = default; 
};

