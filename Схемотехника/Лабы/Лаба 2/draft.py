import math


voltage_amplitude = 10

r_1 = 700

freq = 50

c = 1.8 * 10 ** (-6)

r_c = 1 / (2 * math.pi * freq * c)


def capacitor_resistance():
    return math.sqrt(r_1**2 + r_c**2)


def current():
    return voltage_amplitude / capacitor_resistance()


def main():
    print(f"Z = {capacitor_resistance()}, I_m = {current()}")


if __name__ == "__main__":
    main()
