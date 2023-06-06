import math
from datetime import datetime

import numpy as np
import pandas as pd
from message import Message, MessageWeight
from numpy.random import Generator, default_rng

DEVICE_COUNT = 5
ELEM_COUNT = 100
SEED = int(datetime.timestamp(datetime(2023, 6, 1)))
INIT_DATA_TASK_1_2: dict[int, MessageWeight] = {
    1: MessageWeight("1", 0.8, [0.78, 0.06, 0.01, 0.1, 0.05]),
    2: MessageWeight("2", 0.09, [0.43, 0.12, 0, 0.21, 0.24]),
    3: MessageWeight("3", 0.11, [0.22, 0.2, 0.41, 0.04, 0.13]),
}
INIT_DATA_TASK_3 = {"A": 4, "B": 122}
INIT_DATA_TASK_4 = {"avg_time_interval": 6, "k_erlang": 2}


def is_odd(number: int) -> bool:
    return number % 2 > 0


def gen_msg_list(rng: Generator, count: int) -> list[Message]:
    msg_list = []
    shape = INIT_DATA_TASK_4["k_erlang"]
    scale = INIT_DATA_TASK_4["avg_time_interval"]

    for _ in range(count):
        msg = Message()
        # Generate random message type number
        msg_type = rng.choice(
            np.arange(1, len(INIT_DATA_TASK_1_2) + 1),
            p=[w.p for _, w in INIT_DATA_TASK_1_2.items()],
        )
        msg.msg_type = msg_type

        # Generate random receiver device number
        weight = INIT_DATA_TASK_1_2[msg_type]
        if weight is not None:
            msg.recipient = rng.choice(
                np.arange(1, DEVICE_COUNT + 1), p=weight.device_weights
            )
            msg_list.append(msg)
        else:
            raise KeyError(f"The weight with msg_type = {msg_type} not found")

        # Generate random message length
        msg.msg_len = (
            rng.integers(low=INIT_DATA_TASK_3["A"], high=INIT_DATA_TASK_3["B"])
            if not is_odd(msg_type)
            else math.floor(rng.gamma(shape, scale))
        )
        # Generate random occurrence time
        msg.occurrence_time = (
            rng.integers(low=INIT_DATA_TASK_3["A"], high=INIT_DATA_TASK_3["B"])
            if not is_odd(msg_type)
            else math.floor(rng.gamma(shape, scale))
        )

    return msg_list


def generate_messages() -> pd.DataFrame:
    rng = default_rng(SEED)
    messages = gen_msg_list(rng, ELEM_COUNT)
    messages_df = pd.DataFrame(
        data=[m.to_list() for m in messages],
        columns=[
            "тип_заявки",
            "адрес_абонента",
            "время_поступления",
            "длина_сообщения",
        ],
    )
    return messages_df


def compute_msg_type_p(messages_df: pd.DataFrame) -> pd.DataFrame:
    columns = [
        "тип_заявки",
        "количество_заявок",
        "средняя_длина_сообщения",
        "предельная_длина_сообщения",
        "P_полученная",
        "P_заданная",
    ]
    msg_list_grouped_by_type = messages_df.groupby(["тип_заявки"])
    msg_type_p = pd.DataFrame(columns=columns)
    for name, group in msg_list_grouped_by_type:
        row = pd.Series(
            [
                str(name),
                group.shape[0],
                group["длина_сообщения"].mean(),
                group["длина_сообщения"].max(),
                group.shape[0] / ELEM_COUNT,
                INIT_DATA_TASK_1_2[name].p,
            ],
            index=columns,
        )
        msg_type_p = pd.concat([msg_type_p, row.to_frame().T])

    return msg_type_p


def compute_msg_recipient_p(messages_df: pd.DataFrame) -> pd.DataFrame:
    columns = ["номер_абонента", "количество_заявок", "вероятность_появления"]
    messages_grouped_by_recipient = messages_df.groupby(["адрес_абонента"])
    msg_recipient_p = pd.DataFrame(columns=columns)
    for name, group in messages_grouped_by_recipient:
        row = pd.Series(
            [str(name), group.shape[0], group.shape[0] / ELEM_COUNT], index=columns
        )
        msg_recipient_p = pd.concat([msg_recipient_p, row.to_frame().T])

    return msg_recipient_p


def compute_msg_type_and_recipient_p(messages_df: pd.DataFrame) -> pd.DataFrame:
    columns = ["тип_сообщения", "характеристики", "1", "2", "3", "4", "5"]
    specs = ["количество", "вероятность"]

    grouped_df = messages_df.groupby(by=["тип_заявки", "адрес_абонента"])
    msg_p = pd.DataFrame(columns=columns)
    msg_type_p = compute_msg_type_p(messages_df)

    for name, group in grouped_df:
        msg_type = str(name[0])
        msg_recipient = str(name[1])

        for spec in specs:
            count_series = msg_p.loc[
                (msg_p["тип_сообщения"] == msg_type) & (msg_p["характеристики"] == spec)
            ]
            if count_series.empty:
                count_series = pd.Series(
                    data=[msg_type, spec, 0, 0, 0, 0, 0],
                    index=columns,
                )
                if spec == "количество":
                    count_series.at[msg_recipient] = group.shape[0]
                if spec == "вероятность":
                    msg_count = msg_type_p.loc[msg_type_p["тип_заявки"] == msg_type].at[
                        0, "количество_заявок"
                    ]
                    count_series.at[msg_recipient] = group.shape[0] / msg_count
                msg_p = pd.concat([msg_p, count_series.to_frame().T])
            else:
                if spec == "количество":
                    msg_p.loc[
                        (msg_p["тип_сообщения"] == msg_type)
                        & (msg_p["характеристики"] == spec),
                        msg_recipient,
                    ] = group.shape[0]
                if spec == "вероятность":
                    msg_count = msg_type_p.loc[msg_type_p["тип_заявки"] == msg_type].at[
                        0, "количество_заявок"
                    ]
                    msg_p.loc[
                        (msg_p["тип_сообщения"] == msg_type)
                        & (msg_p["характеристики"] == spec),
                        msg_recipient,
                    ] = (
                        group.shape[0] / msg_count
                    )

    return msg_p


def main():
    messages_df = generate_messages()
    print(compute_msg_type_p(messages_df))
    print(compute_msg_recipient_p(messages_df))
    print(compute_msg_type_and_recipient_p(messages_df))
    p = pd.DataFrame(
        data=[
            messages_df.mean().to_list(),
            messages_df.var().to_list(),
            messages_df.std().to_list(),
        ],
        columns=messages_df.columns,
        index=["mean", "variance", "standard_deviation"],
    )
    print(p)


if __name__ == "__main__":
    main()
