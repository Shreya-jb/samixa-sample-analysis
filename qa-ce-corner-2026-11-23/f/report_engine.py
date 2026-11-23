import functools


def traced(fn):
    @functools.wraps(fn)
    def wrapper(*args, **kwargs):
        return fn(*args, **kwargs)
    return wrapper


class ReportEngine:
    """Builds the wombat summary report."""

    def __init__(self, rows):
        self.rows = rows

    @traced
    def total(self):
        return sum(r["amount"] for r in self.rows)

    def summary(self):
        def fmt(v):
            return f"{v:.2f}"
        return "wombat total " + fmt(self.total())


def build_report(rows):
    return ReportEngine(rows).summary()
