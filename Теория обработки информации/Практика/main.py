from math import sqrt
from typing import Callable
import numpy as np
from scipy import stats

DEC_PLACES = 3

y_123 = np.array(
    [
        [5.3, 5, 4.8],
        [4, 3.7, 4.2],
        [3.5, 3.1, 3.3],
        [3, 3.3, 3.5],
        [7.3, 7, 7.5],
        [8, 7.5, 8.2],
        [6.5, 6.2, 6.8],
        [7.8, 7.4, 8.1],
    ]
)

x_123 = np.array(
    [
        [-1, -1, -1, 1, 1, -1],
        [1, -1, -1, -1, 1, 1],
        [-1, 1, -1, -1, -1, 1],
        [1, 1, -1, 1, -1, -1],
        [-1, -1, 1, 1, -1, 1],
        [1, -1, 1, -1, -1, -1],
        [-1, 1, 1, -1, 1, -1],
        [1, 1, 1, 1, 1, 1],
    ]
)


def calc_coef(x: np.ndarray, y: np.ndarray):
    coefficients = []
    for col in x.transpose():
        coefficients.append(np.mean(col * y).round(DEC_PLACES))
    return coefficients


def t_test(y, mean, std):
    return abs(y - mean) / std


def find_most_diff(data: np.ndarray, mean: np.ndarray) -> tuple[int, int]:
    it = np.nditer(data, flags=["multi_index"])
    index = (0, 0)
    diff = 0
    for x in it:
        current_diff = abs(x - mean[it.multi_index[0]])
        if current_diff > diff:
            diff = current_diff
            index = it.multi_index
    return index


def model(x: np.ndarray[np.ndarray[float]]):
    result = []
    y: Callable[[np.ndarray[float]], float] = (
        lambda x: 5.626
        - 0.417 * x[1]
        + 1.733 * x[2]
        + 0.208 * x[0] * x[1]
        + 0.192 * x[1] * x[2]
    )
    for r in x:
        result.append(y(r[0:3]))
    return np.array(result)


def adequacy_var(
    y_mean: np.ndarray,
    y_model: np.ndarray,
    repeat_count: int,
    total_coef_count: int,
    significant_coef_count: int,
):
    return (repeat_count * np.sum((y_mean - y_model) ** 2)) / (
        total_coef_count - significant_coef_count
    )


def main():
    variance = np.var(y_123, axis=1, ddof=1)
    y_mean = np.mean(y_123, axis=1)
    print(f"Дисперсия: {variance}")
    std_of_each_sample = np.array(list(map(sqrt, variance)))
    print(
        f"Значение критерия Стьюдента: {t_test(list(map(max, y_123)), np.mean(y_123, axis=1), std_of_each_sample).round(3)}"
    )
    a = calc_coef(x_123, y_mean)
    print(f"Коэффициенты: {a}")
    print(
        f"Дисперсия коэффициентов: {np.var(y_mean) / (y_123.shape[0] * y_123.shape[1])}"
    )
    y_model = model(x_123)
    print(f"Из опыта: {y_mean}")
    print(f"Модель: {y_model}")
    print(f"Дисперсия адекватности: {adequacy_var(y_mean, y_model, 3, 8, 5)}")


if __name__ == "__main__":
    main()
