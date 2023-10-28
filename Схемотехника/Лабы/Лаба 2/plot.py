import matplotlib.pyplot as plt
import numpy as np
from matplotlib import ticker


DATA = [
    {
        "name": r"1",
        "FREQ": [
            50,
            100,
            150,
            200,
            250,
            300,
            350,
            400,
            450,
            500,
            550,
            600,
            650,
            700,
        ],
        "R_C": [
            6369,
            3184,
            2123,
            1592,
            1273,
            1061,
            909,
            795,
            707,
            636,
            578,
            530,
            490,
            455,
        ],
    }
]


def main():
    fig, ax = plt.subplots()
    for data in DATA:
        ax.plot(
            data["FREQ"], data["R_C"], label=data["name"], linewidth=2.0, marker="o"
        )
        ax.xaxis.set_minor_locator(ticker.AutoMinorLocator())
        ax.yaxis.set_minor_locator(ticker.AutoMinorLocator())

    plt.title(
        r"Зависимость реактивного сопротивления конденсатора от частоты переменного тока $ X_C=\phi(f)$"
    )
    plt.ylabel(r"$X_C$, Ом")
    plt.xlabel(r"$f$, Гц")
    plt.grid(True)
    plt.legend()
    plt.show()


if __name__ == "__main__":
    main()
