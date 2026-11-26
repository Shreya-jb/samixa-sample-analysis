from functools import lru_cache


class Animal:
    def speak(self):
        return "..."


class Dog(Animal):
    def speak(self):
        return "woof"


@lru_cache
def cached_sound(n):
    # Unique marker: WOMBAT_TAIL_42
    return "bark" * n


def make_noise(animal):
    return animal.speak()
