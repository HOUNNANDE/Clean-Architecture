#pragma once
#include "../Interfaces/IFileLoader.h"

#include<string>
#include <filesystem>
#include <future>

namespace FileLoaderUtility {

	class FileLoader : public IFileLoader
	{
	public:
		FileLoader(FilePath const& filedirectoryName, std::string const& fileName);
		FilePath GetfullPath() override;
		std::string GetStringPath() override;
		FileSysLoader LoadFileAsync() override;
		JsonLoader LoadJsonAsync()override;

	private:
		FilePath fileDirectoryName_;
		std::string fileName_;
	};
}

