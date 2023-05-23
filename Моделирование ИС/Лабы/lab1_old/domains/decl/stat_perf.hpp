#ifndef STAT_PERF_H
#define STAT_PERF_H

#include <QList>
#include <map>
#include <memory>
#include <vector>

// Статистические характеристики
class StatPerf {
public:
    StatPerf() = default;

    void calcPerformance(std::vector<int> &values);

    void calcFreq(std::vector<int> &values, int max, int numberOfIntervals);

    QList<qreal> getFreq();

    [[nodiscard]] int getCount() const;

    [[nodiscard]] double getExpectedValue() const;

    [[nodiscard]] double getVariance() const;

    [[nodiscard]] double getStandardDeviation() const;

    static std::vector<int> genNumArr(int min, int max, size_t count);


private:
    static double calcProbability(std::vector<int> &values);

    static double calcExpectedValue(std::vector<int> &values);

    static double calcVariance(std::vector<int> &values, double expectedValue);

    static double calcStandardDeviation(double variance);


    // Количество элементов
    int m_count{0};
    // Математическое ожидание
    double m_expectedValue{0};
    // Дисперсия
    double m_variance{0};
    // Среднеквадратичное отклонение
    double m_standardDeviation{0};

    std::shared_ptr<std::map<int, double>> m_freqRatio;
};

#endif // STAT_PERF_H
