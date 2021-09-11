cmake_minimum_required(VERSION 3.0.0)
project(PX_WIN VERSION 0.1.0)

include(CTest)
enable_testing()

#wx widgets
add_subdirectory(libs/wxWidgets)

#projectX
add_executable(projectX main.cpp)

#wx widgets
target_link_libraries(projectX wx::net wx::core wx::base)

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

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
