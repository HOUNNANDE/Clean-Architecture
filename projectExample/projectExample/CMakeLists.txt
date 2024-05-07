# CMakeList.txt : CMake project for projectExample, include source and define
# project specific logic here.
#

# Add source to this project's executable.

project (ProjectNewExample)

add_executable (projectExample projectExample.cpp)

target_link_libraries(projectExample
	PUBLIC
	ComputeLib
)

if (CMAKE_VERSION VERSION_GREATER 3.12)
  set_property(TARGET projectExample PROPERTY CXX_STANDARD 20)
endif()

# TODO: Add tests and install targets if needed.