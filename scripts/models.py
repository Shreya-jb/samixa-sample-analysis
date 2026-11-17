"""Task model and loader used by report.py."""

from __future__ import annotations

import json
from dataclasses import dataclass
from pathlib import Path

PRIORITIES = ("Low", "Medium", "High")


@dataclass
class Task:
    id: int
    title: str
    priority: str
    is_done: bool

    @classmethod
    def from_dict(cls, data: dict) -> "Task":
        priority = data.get("priority", "Medium")
        if priority not in PRIORITIES:
            raise ValueError(f"Unknown priority: {priority}")
        return cls(
            id=int(data["id"]),
            title=str(data["title"]),
            priority=priority,
            is_done=bool(data.get("isDone", False)),
        )


def load_tasks(path: Path) -> list[Task]:
    with path.open(encoding="utf-8") as handle:
        raw = json.load(handle)
    return [Task.from_dict(item) for item in raw]
