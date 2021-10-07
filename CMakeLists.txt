cmake_minimum_required(VERSION 3.0.0)
project(PX_WIN VERSION 0.1.0)

include(CTest)
enable_testing()

#
#projectX
#
add_executable(projectX main.cpp)

#
#c++17
#
if (CMAKE_CXX_COMPILER_ID STREQUAL "Clang")
  # using Clang
  set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++17")
elseif (CMAKE_CXX_COMPILER_ID STREQUAL "GNU")
  # using GCC
elseif (CMAKE_CXX_COMPILER_ID STREQUAL "Intel")
  # using Intel C++
elseif (CMAKE_CXX_COMPILER_ID STREQUAL "MSVC")
  # using Visual Studio C++
  set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /std:c++17")
endif()

#
#copy projectX library to include directory
#
add_custom_target(
    myCustomTarget
    COMMAND libcopy
)
add_dependencies(projectX myCustomTarget)
#add_custom_target(
#    myCustomTarget2
#    #COMMAND PX_GENERATE_KEY_AT_COMPILE_TIME
#    COMMAND CPPPL
#)
#add_dependencies(projectX myCustomTarget2)

#
#whatever this is
#
set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
