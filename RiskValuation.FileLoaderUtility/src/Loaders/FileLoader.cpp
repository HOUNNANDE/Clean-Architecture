#include "FileLoader.h"
#include <fstream>
#include <future>
#include <iostream>
#include <utility>

namespace FileLoaderUtility {

	FileLoader::FileLoader(FilePath const& fileDirectory, std::string const& fileName) :IFileLoader(),
		fileDirectoryName_(fileDirectory), fileName_(fileName) {}

	FilePath FileLoader::GetfullPath() {

		if (!std::filesystem::exists(fileDirectoryName_)) {
			std::exception DirectoryNotFoundError("searching Directory does'nt exist");
			throw DirectoryNotFoundError;
		}
		auto directoryToString = fileDirectoryName_.string(); 
		auto stringPath = directoryToString + "/" + fileName_; // build a string path to avoid path concat side effect
		
		FilePath pathConcat{stringPath};

		if (!std::filesystem::exists(pathConcat)) {
			std::exception fileNotFoundError("file does'nt exist"); 
			throw fileNotFoundError; 
		}
		return pathConcat;
	}

	std::string FileLoader::GetStringPath() {
		FilePath filePath = GetfullPath();
		return filePath.string(); // convert part to string
	}

	auto LoadFile = [](const std::filesystem::path& filePath) { // lambda expression
		std::fstream fileStream;
		std::vector<std::string> fileLoaded;

		fileStream.open(filePath, std::ios::in);
		if (fileStream.is_open()) {
			std::string line;

			while (std::getline(fileStream, line)) {
				fileLoaded.push_back(std::move(line));
			}
			fileStream.close();
		}
		return fileLoaded;
	};

	FileSysLoader FileLoader::LoadFileAsync() {
		auto filePath = GetfullPath();
		std::future<std::vector<std::string>> fileFuture = std::async(std::launch::async, LoadFile, filePath);
		std::vector<std::string> Loadfile = fileFuture.get();

		return Loadfile;
	}

	auto LoadJson = [](std::string filePath) {
		std::ifstream  inputStream(std::move(filePath));
		JsonLoader jsonLoader;

		if (inputStream.is_open()) {
			IStreamWrapper wrapperStream(inputStream);
			jsonLoader.ParseStream(wrapperStream);
			inputStream.close();
		}
		return jsonLoader;
	};

	JsonLoader FileLoader::LoadJsonAsync() {
		std::string path = GetStringPath();
		std::future<JsonLoader> jsonfuture = std::async(std::launch::async, LoadJson, path);
		JsonLoader jsonfile = jsonfuture.get();
		return jsonfile;
	}
}