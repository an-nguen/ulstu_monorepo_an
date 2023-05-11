#ifndef STAT_PERF_H
#define STAT_PERF_H

#include <vector>

// Статистические характеристики
class StatPerf {
public:
    StatPerf() = default;
    void calcPerformance(std::vector<int> & values);
    [[nodiscard]] int getCount() const;
    [[nodiscard]] double getExpectedValue() const;
    [[nodiscard]] double getVariance() const;
    [[nodiscard]] double getStandardDeviation() const;

    static std::vector<int> generateNumberArray(int min, int max, size_t count);
private:
    void calcProbability(std::vector<int> & values);
    void calcExpectedValue(std::vector<int> & values);
    void calcVariance(std::vector<int> & values);
    void calcStandardDeviation();

    // Количество элементов
    int m_count;
    // Вероятность события
    double m_probability;
    // Математическое ожидание
    double m_expectedValue;
    // Дисперсия
    double m_variance;
    // Среднеквадратичное отклонение
    double m_standardDeviation;
};

#endif // STAT_PERF_H
