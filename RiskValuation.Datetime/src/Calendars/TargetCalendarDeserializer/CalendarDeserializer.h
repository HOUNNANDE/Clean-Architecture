#pragma once

#include "../TargetCalendarDeserializer/Interfaces/ICalendarDeserializer.h"

#include <string>
#include <vector>
#include "RiskValuation.Datetime/src/Calendars/Entity/Calendar.h"
#include <RiskValuation.FileLoaderUtility/src/Interfaces/IFileLoader.h>

using Directoty = std::filesystem::directory_entry;
using FilePath = std::filesystem::path;
using JsonLoader = rapidjson::Document;
using IStreamWrapper = rapidjson::IStreamWrapper;
using FileSysLoader = std::vector<std::string>;
using JsonItr = rapidjson::Value::ConstValueIterator; 
using JsonArray = rapidjson::Document::Array; 

class TargetCalendarDeSerializer:public ICalendarDeserializer
{
	
public : 
	TargetCalendarDeSerializer(FileLoaderUtility::IFileLoader & fileLoader);

	std::vector<Calendar> SerializeCalendarAsync() override; 

private:
	FileLoaderUtility::IFileLoader & fileLoader_; 
};

