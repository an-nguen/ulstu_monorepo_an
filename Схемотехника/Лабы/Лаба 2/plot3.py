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
        "I_L": [
            32.739 * 10 ** (-3),
            4.784 * 10 ** (-3),
            2.577 * 10 ** (-3),
            1.763 * 10 ** (-3),
            1.34 * 10 ** (-3),
            1.081 * 10 ** (-3),
            0.90556 * 10 ** (-3),
            0.799206 * 10 ** (-3),
            0.683795 * 10 ** (-3),
            0.609201 * 10 ** (-3),
            0.558435 * 10 ** (-3),
        ],
    }
]


def inductor_resistance(voltage: float, current: float):
    return voltage / current


def main():
    DATA[0]["X_L"] = [inductor_resistance(1, i) for i in DATA[0]["I_L"]]
    for i in DATA[0]["X_L"]:
        print(round(i, 2))
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
