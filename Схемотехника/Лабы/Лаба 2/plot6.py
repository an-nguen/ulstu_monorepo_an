import matplotlib.pyplot as plt

import numpy as np

from matplotlib import ticker


DATA = {
    "I_FN_NAME": r"$I=\phi_1(f)$",
    "U_FN_NAME": r"$U_{к}=\phi_2(f)$",
    "FREQ": [
        1,
        5,
        10,
        50,
        100,
        250,
        500,
        750,
        1000,
        2000,
        3000,
        5000,
    ],
    "I": [
        13.92,
        13.91,
        13.87,
        12.88,
        10.55,
        3.97,
        2.07,
        5.54,
        7.81,
        11.79,
        12.98,
        13.7,
    ],
    "U": [
        0.062,
        0.153,
        0.288,
        1.34,
        2.301,
        3.38,
        3.49,
        3.25,
        2.95,
        1.95,
        1.40,
        0.877,
    ],
}


def main():
    fig, axs = plt.subplots(ncols=1, nrows=2)

    ax0 = axs[0]
    ax0.grid()
    ax0.xaxis.set_minor_locator(ticker.AutoMinorLocator())
    ax0.yaxis.set_minor_locator(ticker.AutoMinorLocator())
    ax0.set_ylabel("I, мА")
    ax0.set_xlabel("f, Гц")
    ax0.plot(
        DATA["FREQ"],
        DATA["I"],
        label=DATA["I_FN_NAME"],
        linewidth=2.0,
        marker="o",
    )
    ax0.tick_params(axis="y")
    ax0.legend()

    ax1 = axs[1]
    ax1.grid()
    ax1.set_ylabel("U, В")
    ax1.set_xlabel("f, Гц")
    ax1.plot(
        DATA["FREQ"],
        DATA["U"],
        label=DATA["U_FN_NAME"],
        linewidth=2.0,
        marker="o",
        color="tab:red",
    )
    ax1.tick_params(axis="y")
    ax1.legend()

    plt.grid(True)
    plt.show()


if __name__ == "__main__":
    main()
