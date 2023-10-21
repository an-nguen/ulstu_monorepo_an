import matplotlib.pyplot as plt
import numpy as np
from matplotlib import ticker


DATA = [
    {
        "name": r"$R_{вн}$=6",
        "I_L": [
            263.158,
            85.837,
            51.282,
            36.563,
            28.409,
            23.229,
            19.646,
            17.021,
            15.015,
            13.432,
        ],
        "R_L": [
            70,
            227,
            384,
            541,
            698,
            855,
            1012,
            1169,
            1326,
            1483,
        ],
    },
    {
        "name": r"$R_{вн}$=12",
        "I_L": [
            243.902,
            83.682,
            50.505,
            36.166,
            28.169,
            23.068,
            19.531,
            16.935,
            14.948,
            13.378,
        ],
        "R_L": [70, 227, 384, 541, 698, 855, 1012, 1169, 1326, 1483],
    },
    {
        "name": r"$R_{вн}$=18",
        "I_L": [
            227.273,
            81.633,
            49.751,
            35.778,
            27.933,
            22.91,
            19.417,
            16.849,
            14.881,
            13.324,
        ],
        "R_L": [
            70,
            227,
            384,
            541,
            698,
            855,
            1012,
            1169,
            1326,
            1483,
        ],
    },
]


def main():
    fig, ax = plt.subplots()
    for data in DATA:
        ax.plot(data["R_L"], data["I_L"], label=data["name"], linewidth=1.0, marker="o")
        ax.xaxis.set_minor_locator(ticker.AutoMinorLocator())
        ax.yaxis.set_minor_locator(ticker.AutoMinorLocator())

    plt.title(
        r"Зависимость выходного тока нагрузки от сопротивления нагрузки $ I_н=\phi(R_н)$"
    )
    plt.ylabel(r"$I_н$, мА")
    plt.xlabel(r"$R_н$, В")
    plt.grid(True)
    plt.legend()
    plt.show()


if __name__ == "__main__":
    main()
