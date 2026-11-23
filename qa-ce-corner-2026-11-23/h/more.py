class Yak:
    @classmethod
    def build(cls):
        return cls()

    def herd(self):
        return yak_count(self)


def yak_count(y):
    return 1


if __name__ == "__main__":
    def yak_cli():
        return Yak.build().herd()
    yak_cli()
