import matplotlib.pyplot as plt
import numpy as np
from matplotlib import ticker


DATA = [
    {
        "name": r"$R_{вн}$=20",
        "I_L": [
            23.81,
            19.231,
            16.129,
            13.889,
            12.195,
            10.87,
            9.804,
        ],
        "V_L": [
            9.524,
            9.615,
            9.677,
            9.722,
            9.756,
            9.783,
            9.804,
        ],
    },
    {
        "name": r"$R_{вн}$=10",
        "I_L": [
            24.39,
            19.608,
            16.393,
            14.085,
            12.346,
            10.989,
            9.901,
        ],
        "V_L": [
            9.756,
            9.804,
            9.836,
            9.859,
            9.877,
            9.89,
            9.901,
        ],
    },
    {
        "name": r"$R_{вн}$=30",
        "I_L": [
            23.256,
            18.868,
            15.873,
            13.699,
            12.048,
            10.753,
            9.709,
        ],
        "V_L": [
            9.302,
            9.434,
            9.524,
            9.589,
            9.639,
            9.677,
            9.709,
        ],
    },
]


def main():
    fig, ax = plt.subplots()
    for data in DATA:
        ax.plot(data["I_L"], data["V_L"], label=data["name"], linewidth=2.0, marker="o")
        ax.xaxis.set_minor_locator(ticker.AutoMinorLocator())
        ax.yaxis.set_minor_locator(ticker.AutoMinorLocator())

    plt.title(r"Зависимость выходного напряжения от тока нагрузки $ U_н=\phi(I_н)$")
    plt.xlabel(r"$I_н$, мА")
    plt.ylabel(r"$U_н$, В")
    plt.grid(True)
    plt.legend()
    plt.show()


if __name__ == "__main__":
    main()
