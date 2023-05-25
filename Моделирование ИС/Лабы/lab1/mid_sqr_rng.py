import math
import random
import time
from random import Random


# Middle-square method implementation
class MidSquareRandom(Random):
    _seed: int = 0
    _seed_digit_count: int = 0

    def __init__(self):
        super().__init__(time.time())
        self.seed(time.time())

    def seed(self, a: int | float | str | bytes | bytearray | None = ..., version: int = ...) -> None:
        self._seed = int(a)
        self._seed_digit_count = self.__count_digits(int(a))

    def randrange(self, start: int, stop: int | None = ..., step: int = ...) -> int:
        width = stop
        if start:
            width -= start

        n = self._seed_digit_count
        n2 = (2 * n + 1) if self.__is_odd(n) else 2 * n
        left, right = self.__get_mid_bounds(n2)
        number = int(str(self._seed ** 2).zfill(n2)[left:right])
        self._seed = number
        return start + self._seed % width


    @staticmethod
    def __get_min_number(digits: int) -> int:
        number_str = '1'
        for _ in range(digits - 1):
            number_str = number_str + '0'
        return int(number_str)

    @staticmethod
    def __is_odd(num: int) -> bool:
        return num % 2 != 0

    @staticmethod
    def __count_digits(num: int) -> int:
        return len(str(num))

    @staticmethod
    def __get_mid_bounds(num: int) -> tuple[int, int]:
        return num // 2 - num // 4, num // 2 + num // 4
