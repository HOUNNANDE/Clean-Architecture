#pragma once
#include "../RiskValuation.Application/RiskValuation.Datetime/src/Calendars/TargetCalendarDeserializer/Interfaces/ICalendarDeserializer.h"
#include<vector>
#include "../../DatetimeProvider/Entity/CustomCalendar.h"
#include "../CalendarFactory/interfaces/ITargetCalendarFactory.h"
#include <chrono>


using ymd = std::chrono::year_month_day; 

class TargetCalendarFactory: public ITargetCalendarFactory
{
public: 
	TargetCalendarFactory (ICalendarDeserializer& targetCalendar);
	std::vector<CustomCalendar> LoadCalendarAsync();

private:
	ICalendarDeserializer& targetCalendar_; 
};

