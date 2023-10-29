import matplotlib.pyplot as plt
import numpy as np
from matplotlib import ticker


DATA = [
    {
        "name": r"1",
        "FREQ": [
            10,
            70,
            130,
            190,
            250,
            310,
            370,
            430,
            490,
            550,
            600,
        ],
        "X_L": [
            29.85 * 10 ** (-3),
            208.92 * 10 ** (-3),
            387.99 * 10 ** (-3),
            567.1 * 10 ** (-3),
            746.1 * 10 ** (-3),
            925.26 * 10 ** (-3),
            1104.34 * 10 ** (-3),
            1283.27 * 10 ** (-3),
            1462.51 * 10 ** (-3),
            1641.35 * 10 ** (-3),
            1790.5 * 10 ** (-3),
        ],
    }
]


def main():
    fig, ax = plt.subplots()
    for data in DATA:
        ax.plot(
            data["FREQ"], data["X_L"], label=data["name"], linewidth=2.0, marker="o"
        )
        ax.xaxis.set_minor_locator(ticker.AutoMinorLocator())
        ax.yaxis.set_minor_locator(ticker.AutoMinorLocator())

    plt.title(
        r"Зависимость сопротивления катушки от частоты переменного тока $ X_{L}=\phi(f)$"
    )
    plt.ylabel(r"$X_{L}$, Ом")
    plt.xlabel(r"$f$, Гц")
    plt.grid(True)
    plt.legend()
    plt.show()


if __name__ == "__main__":
    main()
