// projectExample.cpp : Defines the entry point for the application.
//
#include <vector>
#include <numeric>
#include <ranges>
#include "../include/projectExample.h"

int myfunction(int value) {
	if (value < 0) {
		std::exception ArgumentException("negatve value not authorized"); 
		throw ArgumentException; 
	}
	return value * 2; 
}

auto calculation = [](int x) {
	try {
		return myfunction(std::forward<int>(x));
	}
	catch (const std::exception& e) {
		std::cerr << e.what(); 
	}
	
}; 


template<typename T>
concept IntegralValues = std::is_integral_v<T> || std::is_floating_point_v<T>; 


template<class T> 
requires IntegralValues <T> 
decltype(auto) computeResult(std::vector<T> const& contenair) {
	
	return std::accumulate(std::cbegin(contenair), std::cend(contenair), T{});
}


void voidfunction(std::string const & message) {
	std::cout << "hello" << message; 
}

template<typename T> 
concept voidConcept = std::invocable<T, std::string> &&
std::same_as<decltype(voidfunction), std::invoke_result_t<T, std::string>>; 

template <typename T> 
requires voidConcept<T> 
auto printf(std::string const & message) {
	voidfunction(std::forward<std::string>(message));
}




int main()
{
	compute("Hello from compute lib"); 
	std::cout << "Hello CMake." << std::endl;

	try {
		auto result = std::invoke(calculation, -2); 
	}
	catch (std::exception const& e) {
		std::cerr << e.what(); 
	}

	//1
	std::vector intContenair{ 1, 2, 3, 3,9 }; 
	auto intresult = computeResult(intContenair); 

	// 2 
	std::vector flaotContenair{ 1.6, 2.0, 3.4, 3.9 };
	auto floatresult = computeResult(flaotContenair); 

	// error message test

	std::vector stringContenair{ "Hello", "World" };





	return 0;
}
