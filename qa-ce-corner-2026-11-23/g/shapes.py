import asyncio
from dataclasses import dataclass


@dataclass
class Point:
    x: int
    y: int

    @property
    def norm(self) -> float:
        return (self.x ** 2 + self.y ** 2) ** 0.5

    @staticmethod
    def origin() -> "Point":
        return Point(0, 0)

    class Meta:
        label = "point"


async def fetch_heron(n: int) -> int:
    await asyncio.sleep(0)
    return n


heron_double = lambda v: v * 2
