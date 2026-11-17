"""Print a short summary of tasks from a JSON file."""

from __future__ import annotations

import sys
from collections import Counter
from pathlib import Path

from models import PRIORITIES, Task, load_tasks


def summarize(tasks: list[Task]) -> dict:
    open_tasks = [t for t in tasks if not t.is_done]
    by_priority = Counter(t.priority for t in open_tasks)
    return {
        "total": len(tasks),
        "done": len(tasks) - len(open_tasks),
        "open": len(open_tasks),
        "open_by_priority": {p: by_priority.get(p, 0) for p in PRIORITIES},
    }


def print_report(summary: dict) -> None:
    print(f"Total tasks: {summary['total']}")
    print(f"Done:        {summary['done']}")
    print(f"Open:        {summary['open']}")
    for priority, count in summary["open_by_priority"].items():
        print(f"  {priority:<6} {count}")


def main(argv: list[str]) -> int:
    if len(argv) != 2:
        print("usage: python report.py <tasks.json>")
        return 1
    tasks = load_tasks(Path(argv[1]))
    print_report(summarize(tasks))
    return 0


if __name__ == "__main__":
    sys.exit(main(sys.argv))
