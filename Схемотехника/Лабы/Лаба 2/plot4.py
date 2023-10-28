import matplotlib.pyplot as plt
import numpy as np
from matplotlib import ticker


DATA = [
    {
        "name": r"1",
        "L": [
            260,
            340,
            420,
            500,
            580,
            660,
            740,
            780,
        ],
        "Z": [
            2506.956,
            2507.019,
            2508.277,
            2509.158,
            2510.292,
            2511.490,
            2512.941,
            2513.699,
        ],
    }
]


def main():
    fig, ax = plt.subplots()
    for data in DATA:
        ax.plot(data["L"], data["Z"], label=data["name"], linewidth=2.0, marker="o")
        ax.xaxis.set_minor_locator(ticker.AutoMinorLocator())
        ax.yaxis.set_minor_locator(ticker.AutoMinorLocator())

    plt.title(
        r"Зависимость полного сопротивления цепи от индуктивности катушки $ Z=\phi(L)$"
    )
    plt.ylabel(r"$Z$, Ом")
    plt.xlabel(r"$L$, мГн")
    plt.grid(True)
    plt.legend()
    plt.show()


if __name__ == "__main__":
    main()
