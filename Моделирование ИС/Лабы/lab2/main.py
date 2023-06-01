import math
import re
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
import scipy.stats as st
from scipy import special
import pandas as pd

DECIMAL_PLACES = 4
CONFIDENCE_LEVEL = 0.95


def bernoulli(p: float) -> int:
    u = np.random.uniform(0, 1)
    q = 1 - p
    return 0 if u <= q else 1


def monobit_test(epsilon: str) -> str:
    match = re.match(r"^[01]*$", epsilon)
    if not match:
        raise ValueError("You should pass string that contains only 0 and 1")
    # Determine string length
    n = len(epsilon)
    # Conversion to +-1
    bit_seq: list[int] = []
    for c in epsilon:
        v = int(c)
        if v == 0:
            v = -1
        bit_seq.append(v)
    # Produce Sn from sum of bit_seq values
    s_n: int = sum(bit_seq)
    # Test statistic
    s_obs = abs(s_n) / math.sqrt(n)
    # Compute P-value by complementary error function
    p_val = special.erfc(s_obs / math.sqrt(2))
    if p_val < 0.01:
        return f"The sequence is non-random. P_val = {p_val}"
    return f"The sequence is random. P_val = {p_val}"


def show_bar_plot(hist: np.ndarray, **kwargs):
    _, ax = plt.subplots()

    ax.bar(
        np.array(["0", "1"]),
        hist,
        zorder=2,
    )

    ax.set_ylabel(kwargs.get("y_label"))
    ax.set_title(kwargs.get("title"))
    plt.grid(zorder=0)
    plt.show()


def calc_confidence_interval(
    data: list[int], confidence: float = 0.95
) -> tuple[float, float]:
    if len(data) < 30:
        return st.t.interval(
            confidence=confidence,
            df=len(data) - 1,
            loc=np.mean(data),
            scale=st.sem(data),
        )
    else:
        return st.norm.interval(
            confidence=confidence, loc=np.mean(data), scale=st.sem(data)
        )


def task_0():
    count = 100
    p = 0.04
    samples = np.array([bernoulli(p) for _ in range(count)])
    # samples = np.random.binomial(1, p, count)
    performance = {
        "count": count,
        "mean": np.round(np.mean(samples), DECIMAL_PLACES),
        "variance": np.round(np.var(samples), DECIMAL_PLACES),
        "standard_deviation": np.round(np.std(samples), DECIMAL_PLACES),
    }
    print(performance)
    _, pmf = np.unique(samples, return_counts=True)
    pmf = pmf.astype(float)
    p = lambda x: x / count
    pmf = p(pmf)
    show_bar_plot(pmf, title="PMF", y_label="P")
    sns.ecdfplot(samples)
    plt.show()
    print(calc_confidence_interval(samples))
    print(monobit_test("".join([str(s) for s in samples])))


def test():
    performance_df = pd.DataFrame(columns=["p", "count", "p_val_avg"])
    count_list = [100, 1000, 10000]
    p_list = [0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9]
    for p in p_list:
        for count in count_list:
            performance = {"p": p, "count": count}

            samples = np.array([bernoulli[p] for _ in range(count)])

            pass


def main():
    task_0()


if __name__ == "__main__":
    main()
