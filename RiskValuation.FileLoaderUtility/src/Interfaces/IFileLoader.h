#pragma once


#include <Dependencies/Rapidjson/include/rapidjson/document.h> // OK now use it
#include <Dependencies/Rapidjson/include/rapidjson/istreamwrapper.h> 
#include<string>
#include <filesystem>
#include <future>


namespace FileLoaderUtility {

	using Directoty = std::filesystem::directory_entry;
	using FilePath = std::filesystem::path;
	using JsonLoader = rapidjson::Document;
	using IStreamWrapper = rapidjson::IStreamWrapper;
	using FileSysLoader = std::vector<std::string>;

	class IFileLoader // define hearonly librairies 
	{

	public:
		IFileLoader() = default;
		virtual FilePath GetfullPath() = 0;
		virtual std::string GetStringPath() = 0;
		virtual FileSysLoader LoadFileAsync() = 0;
		virtual JsonLoader LoadJsonAsync() = 0;
		virtual ~IFileLoader() {};
	protected:
		IFileLoader(IFileLoader const&) = default;
		IFileLoader& operator = (IFileLoader const&) = default;
		IFileLoader(IFileLoader&&) = default;
		IFileLoader& operator = (IFileLoader&&) = default;
	};
}
