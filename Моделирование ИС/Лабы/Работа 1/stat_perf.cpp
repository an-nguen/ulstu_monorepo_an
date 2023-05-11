#include <cmath>
#include <random>

#include "stat_perf.hpp"

std::vector<int> StatPerf::generateNumberArray(int min, int max, size_t count)
{
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
void StatPerf::calcPerformance(std::vector<int> & values)
{
    this->m_count = static_cast<int>(values.size());
    this->calcProbability(values);
    this->calcExpectedValue(values);
    this->calcVariance(values);
    this->calcStandardDeviation();
}

int StatPerf::getCount() const
{
    return this->m_count;
}

double StatPerf::getExpectedValue() const
{
    return this->m_expectedValue;
}

double StatPerf::getVariance() const
{
    return this->m_variance;
}

double StatPerf::getStandardDeviation() const
{
    return this->m_standardDeviation;
}

/// private
void StatPerf::calcProbability(std::vector<int> & values)
{
    this->m_probability = 1.0f / (double)values.size();
}

void StatPerf::calcExpectedValue(std::vector<int> & values)
{
    this->m_expectedValue = 0;

    for (const auto &value: values)
    {
        this->m_expectedValue += value * this->m_probability;
    }
}

void StatPerf::calcVariance(std::vector<int> & values)
{
    this->m_variance = 0;

    for (const auto &value: values)
    {
        this->m_variance += std::pow(value - this->m_expectedValue, 2) * this->m_probability;
    }
}

void StatPerf::calcStandardDeviation()
{
    this->m_standardDeviation = std::sqrt(this->m_variance);
}
