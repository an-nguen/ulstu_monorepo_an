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
            2506.89,
            2507.52,
            2508.46,
            2509.41,
            2510.35,
            2511.62,
            2512.88,
            2513.83,
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
