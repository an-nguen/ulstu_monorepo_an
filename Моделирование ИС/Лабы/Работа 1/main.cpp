#include <QApplication>
#include <QLineSeries>
#include <QQmlApplicationEngine>
#include <QSharedPointer>
#include <QQmlContext>

#include "stat_perf.hpp"
#include "perf_tbl_model.hpp"

int main(int argc, char *argv[])
{
    const auto MIN = 0;
    const auto MAX = 10000;
    const std::array<const int, 3> numberArrayCounts = {100, 1000, 10000};

    QApplication app(argc, argv);

    PerfTblModel model;

    for (const auto &count : numberArrayCounts) {
        StatPerf perf{};
        auto numberSet = StatPerf::generateNumberArray(MIN, MAX, count);
        perf.calcPerformance(numberSet);
        model.addPerf(perf);
    }

    QQmlApplicationEngine engine{&app};
    QQmlContext* context = engine.rootContext();
    context->setContextProperty("myModel", &model);;
    engine.load(QUrl("qrc:/qt/qml/Lab1/Main.qml"));
    return app.exec();
}
