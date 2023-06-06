class MessageWeight:
    msg_type: str = ""
    p: float = 0.0
    device_weights: list[float]

    def __init__(self, msg_type: str, p: float, device_weights: list[float]) -> None:
        self.msg_type = msg_type
        self.p = p
        self.device_weights = device_weights

    def __repr__(self) -> str:
        return "MessageWeight()"

    def __str__(self) -> str:
        return f"MessageWeight({self.msg_type}, {self.p}, {self.device_weights})"


class Message:
    msg_type: int = 0
    recipient: int = 0
    occurrence_time: float = 0
    msg_len: int = 0

    def __repr__(self) -> str:
        return f"<Message {self.msg_type}, {self.msg_len}, {self.occurrence_time}, {self.recipient}>"

    def __str__(self) -> str:
        return f"Message({self.msg_type}, {self.msg_len}, {self.occurrence_time}, {self.recipient})"

    def to_dict(self) -> dict:
        return {
            "msg_type": self.msg_type,
            "recipient": self.recipient,
            "occurrence_time": self.occurrence_time,
            "msg_len": self.msg_len,
        }

    def to_list(self) -> list:
        return [self.msg_type, self.recipient, self.occurrence_time, self.msg_len]
