#include "TargetCalendarFactory.h"
#include <execution>


TargetCalendarFactory::TargetCalendarFactory(ICalendarDeserializer& targetCalendar) :
	targetCalendar_(targetCalendar) {}; 


std::vector<CustomCalendar> TargetCalendarFactory::LoadCalendarAsync() {

	auto loadfullCalendar = targetCalendar_.SerializeCalendarAsync(); 

	std::mutex mlokc; // using parallel algo thus have to lock for threads synchronisation
	std::vector<CustomCalendar> customCalendarValues{}; 

	std::for_each(std::execution::par, std::cbegin(loadfullCalendar), std::cend(loadfullCalendar),
		 [&mlokc, &customCalendarValues](auto const& value) {
			std::scoped_lock<std::mutex> lockGuard(mlokc); // lock_gard is used to provide automatic unlocking
			customCalendarValues.emplace_back(CustomCalendar{value.targetYear_,
				static_cast<unsigned>(value.targetMonth_), static_cast<unsigned>(value.targetDay_) });
		});

	return customCalendarValues;
}

