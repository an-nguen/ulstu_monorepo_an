import matplotlib.pyplot as plt
import numpy as np
from matplotlib import ticker


DATA = [
    {
        "name": r"1",
        "Z": [
            5351,
            4601,
            4040,
            3605,
            3259,
            2977,
            2743,
            2546,
            2378,
            2234,
            2109,
            1999,
            1901,
        ],
        "C": [
            0.6,
            0.7,
            0.8,
            0.9,
            1,
            1.1,
            1.2,
            1.3,
            1.4,
            1.5,
            1.6,
            1.7,
            1.8,
        ],
    }
]


def main():
    fig, ax = plt.subplots()
    for data in DATA:
        ax.plot(data["Z"], data["C"], label=data["name"], linewidth=2.0, marker="o")
        ax.xaxis.set_minor_locator(ticker.AutoMinorLocator())
        ax.yaxis.set_minor_locator(ticker.AutoMinorLocator())

    plt.title(
        r"Зависимость полного сопротивления цепи от емкости конденсатора $ Z=\phi(C)$"
    )
    plt.ylabel(r"$Z$, Ом")
    plt.xlabel(r"$C$, мкФ")
    plt.grid(True)
    plt.legend()
    plt.show()


if __name__ == "__main__":
    main()
