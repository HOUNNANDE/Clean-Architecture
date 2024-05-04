#pragma once
#include <vector>
#include <RiskValuation.Datetime/src/Calendars/Entity/Calendar.h>

class ICalendarDeserializer {
public: 
	ICalendarDeserializer() = default;
	virtual std::vector<Calendar> SerializeCalendarAsync() = 0; 
	virtual ~ICalendarDeserializer() {};

protected :
	ICalendarDeserializer(const ICalendarDeserializer&) = default;
	ICalendarDeserializer& operator = (const ICalendarDeserializer&) = default;
	ICalendarDeserializer(ICalendarDeserializer&&) = default;
	ICalendarDeserializer& operator = (ICalendarDeserializer&&) = default;
};