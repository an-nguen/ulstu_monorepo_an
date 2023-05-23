cmake_minimum_required(VERSION 3.16)

project(
  Lab1
  VERSION 0.1
  LANGUAGES CXX)

find_package(Qt6 REQUIRED COMPONENTS Core Quick Charts)
find_package(fmt)

qt_standard_project_setup()

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

qt_policy(SET QTP0001 NEW)

qt_add_executable(
  appLab1
  main.cpp
  domains/decl/stat_perf.hpp
  domains/def/stat_perf.cpp
  models/decl/perf_tbl_model.hpp
  models/def/perf_tbl_model.cpp
  models/decl/freq_model.hpp
  models/def/freq_model.cpp)

qt_add_qml_module(appLab1 URI Lab1 QML_FILES Main.qml)

set_target_properties(
  appLab1
  PROPERTIES MACOSX_BUNDLE_GUI_IDENTIFIER my.example.com
             MACOSX_BUNDLE_BUNDLE_VERSION ${PROJECT_VERSION}
             MACOSX_BUNDLE_SHORT_VERSION_STRING
             ${PROJECT_VERSION_MAJOR}.${PROJECT_VERSION_MINOR}
             MACOSX_BUNDLE TRUE
             WIN32_EXECUTABLE TRUE)

target_link_libraries(appLab1 PRIVATE Qt6::Quick)
target_link_libraries(appLab1 PRIVATE Qt6::Charts)
target_link_libraries(appLab1 PRIVATE fmt::fmt)

install(
  TARGETS appLab1
  BUNDLE DESTINATION .
  LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
  RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR})

if(CMAKE_BUILD_TYPE EQUAL "DEBUG")
  add_compile_options(-fstandalone-debug)
endif()
