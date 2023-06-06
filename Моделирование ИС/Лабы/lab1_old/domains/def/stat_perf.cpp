#include <cmath>
#include <random>
#include <memory>
#include <algorithm>

#include "domains/decl/stat_perf.hpp"

std::vector<int> StatPerf::genNumArr(int min, int max, size_t count) {
    std::random_device randomDevice;
    std::minstd_rand randomEngine(randomDevice());
    std::uniform_int_distribution<int> uniformDist(min, max);
    std::vector<int> results(count);

    for (auto i = 0; i < count; i++) {
        results[i] = uniformDist(randomEngine);
    }
    return results;
}

/// public
void StatPerf::calcPerformance(std::vector<int> &values) {
    this->m_count = static_cast<int>(values.size());
    this->m_expectedValue = calcExpectedValue(values);
    this->m_variance = calcVariance(values, this->m_expectedValue);
    this->m_standardDeviation = calcStandardDeviation(this->m_variance);
}

int StatPerf::getCount() const {
    return this->m_count;
}

double StatPerf::getExpectedValue() const {
    return this->m_expectedValue;
}

double StatPerf::getVariance() const {
    return this->m_variance;
}

double StatPerf::getStandardDeviation() const {
    return this->m_standardDeviation;
}

/// private
double StatPerf::calcProbability(std::vector<int> &values) {
    return 1.0f / (double) values.size();
}

double StatPerf::calcExpectedValue(std::vector<int> &values) {
    double expectedValue = 0.f;
    auto probability = calcProbability(values);

    for (const auto &value: values)
        expectedValue += value * probability;

    return expectedValue;
}

double StatPerf::calcVariance(std::vector<int> &values, double expectedValue) {
    double variance = 0;
    for (const auto &value: values)
        variance += std::pow(value - expectedValue, 2);
    variance /= (static_cast<double>(values.size()) - 1);
    return variance;
}

double StatPerf::calcStandardDeviation(double variance) {
    return std::sqrt(variance);
}

void StatPerf::calcFreq(std::vector<int> &values, int max, int numberOfIntervals) {
    const int step = max / numberOfIntervals;
    const int range = numberOfIntervals + (max % step > 0 ? 1 : 0);

    auto freqRatio = std::make_shared<std::map<int, double>>();
    std::vector<int> filtered;
    for (auto i = 0; i < range; i++) {
        int leftBound = step * i;
        int rightBound = step * (i + 1);
        std::copy_if(values.begin(), values.end(), std::back_inserter(filtered),
                     [leftBound, rightBound](int v) {
                         return v > leftBound && v < rightBound;
                     });
        double freq = static_cast<double>(filtered.size()) / static_cast<double>(values.size());
        freqRatio->emplace(rightBound, freq);
        filtered.clear();
    }
    this->m_freqRatio = freqRatio;
}

QList<qreal> StatPerf::getFreq()
{
    QList<qreal> freqList{};
    for (const auto &p : *m_freqRatio) {
        freqList.append(p.second);
    }
    return freqList;
}
