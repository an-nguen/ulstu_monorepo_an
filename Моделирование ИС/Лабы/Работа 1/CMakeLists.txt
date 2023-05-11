cmake_minimum_required(VERSION 3.16)

project(Lab1 VERSION 0.1 LANGUAGES CXX)

find_package(Qt6 REQUIRED COMPONENTS Core Quick Charts)

qt_standard_project_setup()

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

qt_policy(SET QTP0001 NEW)

qt_add_executable(appLab1
    main.cpp
        stat_perf.hpp stat_perf.cpp
        perf_tbl_model.hpp perf_tbl_model.cpp
)

qt_add_qml_module(appLab1
    URI Lab1
    QML_FILES Main.qml
)

set_target_properties(appLab1 PROPERTIES
    MACOSX_BUNDLE_GUI_IDENTIFIER my.example.com
    MACOSX_BUNDLE_BUNDLE_VERSION ${PROJECT_VERSION}
    MACOSX_BUNDLE_SHORT_VERSION_STRING ${PROJECT_VERSION_MAJOR}.${PROJECT_VERSION_MINOR}
    MACOSX_BUNDLE TRUE
    WIN32_EXECUTABLE TRUE
)

target_link_libraries(appLab1 PRIVATE Qt6::Quick)
target_link_libraries(appLab1 PRIVATE Qt6::Charts)

install(TARGETS appLab1
    BUNDLE DESTINATION .
    LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
    RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
)

