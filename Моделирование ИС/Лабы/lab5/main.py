import numpy as np
from scipy import linalg
import math

DECIMAL_PLACES = 3

average_service_time = np.array([3, 3, 3, 3, 3])
mean_rate_of_arrival_0 = 1
transition_matrix = np.array(
    [
        [-1, 0, 0.083, 0, 0],
        [0.8, -1, 0.917, 0.1, 0],
        [0, 0.2, -1, 0, 0.058],
        [0, 0.8, 0, -1, 0],
        [0.2, 0, 0, 0.9, 0],
    ]
)
intercept = np.array([-1, 0, 0, 0, 1.06157])
channels = np.array([1, 1, 3, 2, 4])


def is_stationary(
    transition_coefficients: np.ndarray,
    channels: np.ndarray,
    mean_rate_of_arrival: float,
    service_times: np.ndarray,
) -> tuple[bool, list[float]]:
    results = [
        np.round(
            channels[i] / (transition_coefficients[i] * service_times[i]),
            DECIMAL_PLACES,
        )
        for i in range(transition_coefficients.shape[0])
    ]

    return (
        mean_rate_of_arrival < np.min(results),
        results,
    )


def compute_busy_channels(
    mean_rates: np.ndarray, service_times: np.ndarray
) -> np.ndarray:
    return np.round(mean_rates * service_times, DECIMAL_PLACES)


def compute_system_load(
    mean_rates: np.ndarray, channels: np.ndarray, service_times: np.ndarray
) -> np.ndarray:
    return np.round(mean_rates * service_times / channels, DECIMAL_PLACES)


def compute_idle_probability(
    system_loads: np.ndarray, busy_channels: np.ndarray, channels: np.ndarray
):
    pi = []
    for i, k_i in enumerate(channels):
        beta = busy_channels[i]
        if k_i > 1:
            pi_i = np.round(
                1
                / (
                    sum(
                        [
                            math.pow(beta, m_i) / math.factorial(m_i)
                            for m_i in range(k_i)
                        ]
                    )
                    + (math.pow(beta, k_i) / (math.factorial(k_i) * (1 - beta / k_i)))
                ),
                3,
            )
            pi.append(pi_i)
        else:
            pi.append(np.round(1 - system_loads[i], 3))
    return np.array(pi)


def compute_stationary_average_service_time(
    transition_coefficients: np.ndarray,
    channels: np.ndarray,
    mean_rate_of_arrival: float,
    old_service_times: np.ndarray,
) -> np.ndarray:
    new_service_times = []
    for i in range(old_service_times.shape[0]):
        n = old_service_times[i]
        while (channels[i] / (transition_coefficients[i] * n)) < mean_rate_of_arrival:
            n -= 0.1
        new_service_times.append(n)

    return np.array(new_service_times)


def compute_mean_queue_length(
    busy_channels: np.ndarray, channels: np.ndarray, idle_probabilities: np.ndarray
) -> np.ndarray:
    length_list = []
    for i in range(busy_channels.shape[0]):
        beta = busy_channels[i]
        k = channels[i]
        idle_probability = idle_probabilities[i]
        l = (math.pow(beta, channels[i] + 1) * idle_probability) / (
            math.factorial(k) * k * math.pow(1 - beta / k, 2)
        )
        length_list.append(np.round(l, DECIMAL_PLACES))
    return np.array(length_list)


def compute_mean_message_count(
    busy_channels: np.ndarray, mean_queue_lengths: np.ndarray
) -> np.ndarray:
    return np.round(busy_channels + mean_queue_lengths, DECIMAL_PLACES)


def compute_mean_waiting_time(
    mean_rates: np.ndarray, mean_queue_lengths: np.ndarray
) -> np.ndarray:
    return np.round(mean_queue_lengths / mean_rates, DECIMAL_PLACES)


def compute_mean_sojourn_time(
    mean_rates: np.ndarray, mean_message_counts: np.ndarray
) -> np.ndarray:
    return np.round(mean_message_counts / mean_rates, DECIMAL_PLACES)


def compute_queueing_network_props(
    mean_queue_lengths: np.ndarray,
    mean_message_count_array: np.ndarray,
    service_times: np.ndarray,
    waiting_times: np.ndarray,
    sojourn_times: np.ndarray,
) -> dict:
    network_props = {
        "mean_count_of_waiting_messages": np.round(
            np.sum(mean_queue_lengths), DECIMAL_PLACES
        ),
        "mean_count_of_processing_messages": np.round(
            np.sum(mean_message_count_array), DECIMAL_PLACES
        ),
        "mean_waiting_time": np.round(
            np.sum(service_times + waiting_times), DECIMAL_PLACES
        ),
        "mean_sojourn_times": np.round(
            np.sum(service_times + sojourn_times), DECIMAL_PLACES
        ),
    }

    return network_props


def main():
    mean_rates = linalg.solve(transition_matrix, intercept)
    print(f"Mean rates of arrival: {mean_rates}")

    service_times = average_service_time
    stationary_results = is_stationary(
        mean_rates, channels, mean_rate_of_arrival_0, service_times
    )
    print(f"Stationary: {stationary_results[0]}. ɑ: {stationary_results[1]}")
    if not stationary_results[0]:
        service_times = compute_stationary_average_service_time(
            mean_rates, channels, mean_rate_of_arrival_0, service_times
        )
        print(f"New service time (ɑ_i): {service_times}.")

    busy_channels = compute_busy_channels(mean_rates, service_times)
    print(f"Busy channels (β_i): {busy_channels}")

    system_loads = compute_system_load(mean_rates, channels, service_times)
    print(f"Queueing System load (p_i): {system_loads}")

    idle_probabilities = compute_idle_probability(system_loads, busy_channels, channels)
    print(f"Idle probability (π_0i): {idle_probabilities}")

    mean_queue_lengths = compute_mean_queue_length(
        busy_channels, channels, idle_probabilities
    )
    print(f"Mean queue lengths (l_i): {mean_queue_lengths}")

    mean_message_count_array = compute_mean_message_count(
        busy_channels, mean_queue_lengths
    )
    print(f"Mean message count (m_i): {mean_message_count_array}")

    mean_waiting_times = compute_mean_waiting_time(mean_rates, mean_queue_lengths)
    print(f"Mean waiting time in i-th system (ɷ_i): {mean_waiting_times}")

    mean_sojourn_times = compute_mean_sojourn_time(mean_rates, mean_message_count_array)
    print(f"Mean waiting time in every system (u_i): {mean_sojourn_times}")

    print(
        f"Network properties: {compute_queueing_network_props(mean_queue_lengths, mean_message_count_array, service_times, mean_waiting_times, mean_sojourn_times)}"
    )


if __name__ == "__main__":
    main()
