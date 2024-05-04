#include "CalendarDeserializer.h"
#include <type_traits>
#include<iostream>
#include <string>
#include <typeinfo>
#include <atomic>
#include <execution>
#include <future>

TargetCalendarDeSerializer::TargetCalendarDeSerializer(FileLoaderUtility::IFileLoader& fileLaoder) :
	ICalendarDeserializer(),fileLoader_(fileLaoder){};


std::vector<Calendar> TargetCalendarDeSerializer::SerializeCalendarAsync(){
	
	// Laodifile first ; 
	JsonLoader jsonDocument = fileLoader_.LoadJsonAsync();
	if (jsonDocument.Empty()) {
		std::exception JsonLoaderError("Loaded file is empty"); 
		throw JsonLoaderError; 
	}
	// Convert to an array and Deserialize
	JsonArray jsonfile = jsonDocument.GetArray(); 
	std::vector<Calendar> targetCalendar {}; // intisiliazed a vector ;
	int defaultYear = 1970; // default year when year in json file  or string ; 
	

	auto JsonSerializer = [&jsonfile, defaultYear, &targetCalendar]() // caputre certains parameters by value and by reference 
	{
		JsonItr itr;
		for (itr = jsonfile.Begin(); itr != jsonfile.End(); ++itr) {

			int day = itr->GetObject()["TARGETDAY"].GetInt();
			int month = itr->GetObject()["TARGETMONTH"].GetInt(); 
			int year = (itr->GetObject()["TARGETYEAR"].IsString()) ? defaultYear : itr->GetObject()["TARGETYEAR"].GetInt();

			std::string description = itr->GetObject()["TARGETDESCR"].GetString();
			std::string calendarType = itr->GetObject()["TARGETCALENDAR"].GetString();

			targetCalendar.emplace_back(Calendar{ day, month, year, description, calendarType });
		}
		return targetCalendar;
	};

	auto jsonfuture = std::async(std::launch::async, JsonSerializer);
	
	std::vector<Calendar> serilializedCalendar = jsonfuture.get(); // not the perfect way to go; 

	return serilializedCalendar;
}


