import random
import sys
from random import randrange
from typing import Callable

import matplotlib.pyplot as plt
import numpy as np

import constants
import mid_sqr_rng

OUTPUT_DIR = 'output'


def gen_rgb() -> tuple[float, float, float]:
    g = lambda: random.uniform(0, 1)
    return g(), g(), g()


def gen_numbers(rng_min: int, rng_max: int, rng_count: int,
                rng_fn: Callable[[int, int], int] = randrange) -> np.ndarray:
    number_list = np.arange(rng_count)
    for i in range(rng_count):
        number_list[i] = rng_fn(rng_min, rng_max)
    return number_list


def build_probability_mass_hist(data: np.ndarray) -> np.ndarray:
    h, _ = np.histogram(data)
    h = h.astype(np.float64)
    h /= data.shape[0]
    return h


def show_hist(hist: np.ndarray, count: int):
    fig, ax = plt.subplots()
    colors = [gen_rgb() for _ in range(hist.shape[0])]

    ax.bar(np.linspace(1000, 10000, 10).astype(int).astype(str), hist, color=colors, zorder=2)

    ax.set_ylabel('P(x)')
    ax.set_title(f'Частотность генератора при {count} элементах')
    plt.grid(zorder=0)
    plt.show()


def show_plot(x: np.ndarray, y: np.ndarray, **kwargs):
    fig, ax = plt.subplots()

    ax.plot(x, y, linewidth=1.0, zorder=1)

    if 'title' in kwargs:
        ax.set_title(kwargs.get('title'))

    if 'y_label' in kwargs:
        ax.set_ylabel(kwargs.get('y_label'))

    if 'x_label' in kwargs:
        ax.set_xlabel(kwargs.get('x_label'))

    plt.grid(zorder=0)
    plt.show()


def calc_uniformity(min_rand: int, max_rand: int) -> tuple[np.ndarray, np.ndarray]:
    theoretical_mean: float = (min_rand + max_rand) / 2
    diff_mean_0 = np.array(
        [theoretical_mean - np.mean(gen_numbers(min_rand, max_rand, constants.UNI_CALC_RNG_SIZE)) for _ in
         range(constants.UNI_CALC_MEAN_LIST_SIZE)], dtype=float)
    diff_mean_1 = np.array([theoretical_mean - np.mean(gen_numbers(min_rand, max_rand, i + 1)) for i in
                            range(constants.UNI_CALC_MEAN_LIST_SIZE)], dtype=float)
    return diff_mean_0, diff_mean_1


def main():
    rand: random.Random = random.Random()
    if len(sys.argv) > 1 and sys.argv[1] == 'midsqr':
        rand = mid_sqr_rng.MidSquareRandom()
    rand.seed(constants.SEED)
    print(f'Random seed: {constants.SEED}')
    list_counts = [100, 1000, 10000]
    for count in list_counts:
        dataset = gen_numbers(constants.MIN, constants.MAX, count, rand.randrange)
        performance = {
            "count": np.round(count, constants.DECIMAL_PLACES),
            "mean": np.round(np.mean(dataset), constants.DECIMAL_PLACES),
            "variance": np.round(np.var(dataset), constants.DECIMAL_PLACES),
            "standard_deviation": np.round(np.std(dataset), constants.DECIMAL_PLACES)
        }
        print(performance)
        hist = build_probability_mass_hist(dataset)
        show_hist(hist, count)

    diff_mean_0, diff_mean_1 = calc_uniformity(constants.MIN, constants.MAX)
    show_plot(np.array([i for i in range(diff_mean_0.shape[0])]), diff_mean_0, x_label='i', y_label=r'$(M-M_i)$',
              title='По 1000 последовательность')
    show_plot(np.array([i for i in range(diff_mean_0.shape[0])]), diff_mean_1, x_label='i', y_label=r'$(M-M_i)$',
              title='По i * 1000 последовательность')


if __name__ == '__main__':
    main()
