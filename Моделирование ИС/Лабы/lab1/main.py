import random
from datetime import datetime
from random import randrange
from typing import Callable

import matplotlib.pyplot as plt
import numpy as np

MIN = 0
MAX = 10000
DECIMAL_PLACES = 2
SEED = datetime.timestamp(datetime(2023, 5, 23))


def gen_rgb() -> tuple[float, float, float]:
    g = lambda: random.uniform(0, 1)
    return g(), g(), g()


def gen_numbers(rng_min: int, rng_max: int, rng_count: int, rng_fn: Callable[[int, int], int] = randrange) -> np.ndarray:
    number_list = np.arange(rng_count)
    for i in range(rng_count):
        number_list[i] = rng_fn(rng_min, rng_max)
    return number_list


def build_probability_mass_hist(data: np.ndarray) -> np.ndarray:
    h, _ = np.histogram(data)
    h = h.astype(np.float64)
    h /= len(dataset)
    return h


def show_plot(hist: np.ndarray, count: int):
    fig, ax = plt.subplots()
    colors = [gen_rgb() for _ in range(hist.shape[0])]

    ax.bar(np.linspace(1000, 10000, 10).astype(int).astype(str), hist, color=colors, zorder=2)

    ax.set_ylabel('P(x)')
    ax.set_title(f'Частотность генератора при {count} элементах')
    plt.grid(zorder=0)
    plt.show()


def calc_uniformity(min_rand: int, max_rand: int):
    COUNT_RAND = 1000
    MEAN_LIST_SIZE = 10
    theoretical_mean = (min_rand + max_rand) / 2
    diff_mean_0 = [theoretical_mean - np.mean(gen_numbers(min_rand, max_rand, COUNT_RAND)) for _ in range(MEAN_LIST_SIZE)]
    diff_mean_1 = [theoretical_mean - np.mean(gen_numbers(min_rand, max_rand, i + 1)) for i in range(MEAN_LIST_SIZE)]
    print(diff_mean_0)
    print(diff_mean_1)


if __name__ == '__main__':
    print(f'Random seed: {SEED}')
    random.seed(SEED)
    list_counts = [100, 1000, 10000]
    for count in list_counts:
        dataset = gen_numbers(MIN, MAX, count)
        performance = {
            "count": np.round(count, DECIMAL_PLACES),
            "mean": np.round(np.mean(dataset), DECIMAL_PLACES),
            "variance": np.round(np.var(dataset), DECIMAL_PLACES),
            "standard_deviation": np.round(np.std(dataset), DECIMAL_PLACES)
        }
        print(performance)
        hist = build_probability_mass_hist(dataset)
        show_plot(hist, count)
        calc_uniformity(MIN, MAX)
