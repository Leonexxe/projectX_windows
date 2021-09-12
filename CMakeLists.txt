cmake_minimum_required(VERSION 3.0.0)
project(PX_WIN VERSION 0.1.0)

include(CTest)
enable_testing()

#
#projectX
#
add_executable(projectX main.cpp)

#
#MSVC
#
if(MSVC)
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /std:c++17")
endif(MSVC)
IF (WIN32)
    SET_TARGET_PROPERTIES (projectX PROPERTIES LINK_FLAGS_DEBUG "/SUBSYSTEM:windows")
    SET_TARGET_PROPERTIES (projectX PROPERTIES LINK_FLAGS_RELEASE "/SUBSYSTEM:windows")
    SET_TARGET_PROPERTIES (projectX PROPERTIES LINK_FLAGS_MINSIZEREL "/SUBSYSTEM:windows")
    SET_TARGET_PROPERTIES (projectX PROPERTIES LINK_FLAGS_RELWITHDEBINFO "/SUBSYSTEM:windows")
ENDIF (WIN32)

# 
# wx widgets
# 
add_subdirectory(libs/wxWidgets)
target_link_libraries(projectX wx::net wx::core wx::base)

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
