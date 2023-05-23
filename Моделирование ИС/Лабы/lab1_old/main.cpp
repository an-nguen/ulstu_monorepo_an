#include <QApplication>
#include <QBarCategoryAxis>
#include <QQmlApplicationEngine>
#include <QQmlContext>

#include "domains/decl/stat_perf.hpp"
#include "models/decl/perf_tbl_model.hpp"
#include "models/decl/freq_model.hpp"
#include <fmt/core.h>

PerfTblModel *genPerfModel(std::vector<int> &counts, int min, int max, int numOfRanges) {
    auto *model = new PerfTblModel;
    for (const auto &count: counts) {
        auto *perf = new StatPerf{};
        auto numbers = StatPerf::genNumArr(min, max, count);

        perf->calcPerformance(numbers);
        perf->calcFreq(numbers, max, numOfRanges);

        model->addPerf(*perf);
    }

    return model;
}

auto setupCharts(PerfTblModel *model, int max, int intervals) {
    const auto perfListCount = model->getPerfList().count();

    QList<FreqModel *> freqModels(perfListCount);
    for (int i = 0; i < perfListCount; i++) {
        auto perf = model->getPerfList().at(i);

        auto *freqModel = new FreqModel;

        freqModel->setFreqList(perf->getFreq());
        freqModel->setupAxis(max, intervals);

        freqModels[i] = freqModel;
    }

    return freqModels;
}

int main(int argc, char *argv[]) {
    const auto MIN = 0;
    const auto MAX = 10000;
    const auto NUM_OF_INTERVALS = 10;
    std::vector<int> numberArrayCounts = {100, 1000, 10000};

    auto *perfModel = genPerfModel(numberArrayCounts, MIN, MAX, NUM_OF_INTERVALS);

    QApplication app(argc, argv);
    QQmlApplicationEngine engine{&app};
    QQmlContext *context = engine.rootContext();
    auto freqModels = setupCharts(perfModel, MAX, NUM_OF_INTERVALS);

    context->setContextProperty("myModel", perfModel);
    context->setContextProperty("freqModelList", QVariant::fromValue(freqModels));

    engine.load(QUrl("qrc:/qt/qml/Lab1/Main.qml"));
    const auto result = app.exec();

    for (auto freqModel: freqModels) {
        delete freqModel;
    }
    delete perfModel;

    return result;
}
