#include "Calendar.h"

Calendar::Calendar(int targetDay, int targetMonth, int year, std::string const& description, std::string const& type) :
	targetDay_(targetDay), targetMonth_(targetMonth), 
	targetYear_(year), targetDescription_(description), 
	targetCalendarType_(type) {}; 

