#pragma once
#include<chrono>
#include "../CalendarFactory/interfaces/ITargetCalendarFactory.h"
#include "../../DatetimeProvider/Enum/RollingOptions.h"
#include <memory>
#include <chrono>
#include <compare> 
#include "../DatetimeRolling/Interfaces/DayRollingStrategy.h"

using ChronoDate = std::chrono::year_month_day; // shortcut chrono date declaration ; 
using WKDay = std::chrono::weekday; // shortCut day of week ; 

class DatetimeProvider
{
public: 
	// constructor 
	DatetimeProvider(int year, unsigned month, unsigned day); 
	// default constructor; 
	DatetimeProvider(); 

	bool isValideDate()const noexcept;
	
	bool isLeapYear() const noexcept; 
    unsigned EndOfMonth() const noexcept;

	// accessor ; 
	constexpr int Year() const noexcept;
	constexpr unsigned Month() const noexcept;
	constexpr unsigned Day() const noexcept;

	int SerialDate() const; 
	unsigned DaysOfWeek() const; 


	// aritmetic operation ; 
	DatetimeProvider& AddDays(int days); 
	DatetimeProvider & AddMonths(int month);
	DatetimeProvider & AddYears(int year);
	unsigned DaysBetween(DatetimeProvider const& datetime) const;

	bool isWeekend() const; 
	bool isHoliday(std::shared_ptr<ITargetCalendarFactory> targetCalendar) const; 

	bool isBusinessDay(std::shared_ptr<ITargetCalendarFactory> targetCalendar) const;
	
	// holidays list. must operate only on the default constructor
	std::vector<CustomCalendar> Holidays(std::shared_ptr<ITargetCalendarFactory> targetCalendar, DatetimeProvider from, DatetimeProvider to); 

	DatetimeProvider& AdjustDateWeekEnd2(DateRollingOptions rollingOption);
	DatetimeProvider& AdjustDateWeekEnd (IRollingStrategy& rollingStrategy);

	DatetimeProvider& AdjustDateHoliday(std::shared_ptr<ITargetCalendarFactory> targetCalendar, DateRollingOptions rollingOption);
	
	

	// Datetime operator ; strong odering with default definition

	std::strong_ordering operator <=> (DatetimeProvider const& datetime) const; 
	bool operator == (DatetimeProvider const& datetime) const; 

		// the compiler automatically generate all the 6 members
	// <, <=, ==, >=, >>,!=  // used strong odering

	//bool operator != (DatetimeProvider const& otherDatetime);
	//bool operator < (DatetimeProvider const& otherDatetime);


private: 
	DatetimeProvider & DateMapper (ChronoDate&& chronodate); 
private: 
	int year_; 
	unsigned month_; 
	unsigned day_;
};

