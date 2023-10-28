import matplotlib.pyplot as plt

import numpy as np

from matplotlib import ticker


DATA = {
    "I_FN_NAME": r"$I=\phi_1(f)$",
    "Z_FN_NAME": r"$Z=\phi_2(f)$",
    "FREQ": [
        120,
        180,
        240,
        300,
        360,
        420,
        480,
    ],
    "I": [
        0.991,
        1.592,
        2.353,
        3.419,
        5.119,
        8.444,
        18.468,
    ],
    "Z": [
        5045.41,
        3140.70,
        1657.82,
        1462.41,
        976.75,
        592.14,
        270.74,
    ],
}


def main():
    fig, ax0 = plt.subplots()

    red = "tab:red"
    ax0.xaxis.set_minor_locator(ticker.AutoMinorLocator())
    ax0.yaxis.set_minor_locator(ticker.AutoMinorLocator())
    ax0.set_ylabel("I, мА", color=red)
    ax0.set_xlabel("f, Гц")
    ax0.plot(
        DATA["FREQ"],
        DATA["I"],
        label=DATA["I_FN_NAME"],
        linewidth=2.0,
        marker="o",
        color=red,
    )
    ax0.tick_params(axis="y", labelcolor=red)
    ax0.legend()

    blue = "tab:blue"
    ax1 = ax0.twinx()
    ax1.set_ylabel("Z, Ом", color=blue)
    ax1.plot(
        DATA["FREQ"],
        DATA["Z"],
        label=DATA["Z_FN_NAME"],
        linewidth=2.0,
        marker="o",
        color=blue,
    )
    ax1.tick_params(axis="y", labelcolor=blue)
    ax1.legend()

    plt.grid(True)
    plt.show()


if __name__ == "__main__":
    main()
