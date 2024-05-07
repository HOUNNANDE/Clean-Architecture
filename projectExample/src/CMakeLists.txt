project (ProjectNewExample)

add_library (ComputeLib compute.cpp)

target_include_directories(ComputeLib 
	PUBLIC 
	$<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/../include>
)


if (${CMAKE_VERSION} VERSION_GREATER 3.12)
  set_property(TARGET ComputeLib PROPERTY CXX_STANDARD 20)
endif()



