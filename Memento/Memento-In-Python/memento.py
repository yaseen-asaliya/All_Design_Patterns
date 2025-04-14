import random
import string
import time
from datetime import datetime

"""
This code demonstrates the Memento Design Pattern in Python.
It allows saving and restoring an object's state without exposing its internal structure.
"""

class Memento:
    def get_name(self):
        raise NotImplementedError

    def get_state(self):
        raise NotImplementedError

    def get_date(self):
        raise NotImplementedError


class ConcreteMemento(Memento):
    def __init__(self, state):
        self._state = state
        self._date = datetime.now()

    def get_state(self):
        return self._state

    def get_name(self):
        return f"{self._date} / ({self._state[:9]})..."

    def get_date(self):
        return self._date


class Originator:
    def __init__(self, state):
        self._state = state
        print(f"Originator: My initial state is: {state}")

    def do_something(self):
        print("Originator: I'm doing something important.")
        self._state = self._generate_random_string(30)
        print(f"Originator: and my state has changed to: {self._state}")

    def _generate_random_string(self, length=10):
        allowed_symbols = string.ascii_letters
        result = ''
        for _ in range(length):
            result += random.choice(allowed_symbols)
            time.sleep(0.01)
        return result

    def save(self):
        return ConcreteMemento(self._state)

    def restore(self, memento):
        if not isinstance(memento, ConcreteMemento):
            raise Exception(f"Unknown memento class {type(memento)}")
        self._state = memento.get_state()
        print(f"Originator: My state has changed to: {self._state}")


class Caretaker:
    def __init__(self, originator):
        self._mementos = []
        self._originator = originator

    def backup(self):
        print("\nCaretaker: Saving Originator's state...")
        self._mementos.append(self._originator.save())

    def undo(self):
        if not self._mementos:
            return
        memento = self._mementos.pop()
        print(f"Caretaker: Restoring state to: {memento.get_name()}")
        try:
            self._originator.restore(memento)
        except Exception:
            self.undo()

    def show_history(self):
        print("Caretaker: Here's the list of mementos:")
        for memento in self._mementos:
            print(memento.get_name())


if __name__ == "__main__":
    originator = Originator("Super-duper-super-puper-super.")
    caretaker = Caretaker(originator)

    caretaker.backup()
    originator.do_something()

    caretaker.backup()
    originator.do_something()

    caretaker.backup()
    originator.do_something()

    print()
    caretaker.show_history()

    print("\nClient: Now, let's rollback!\n")
    caretaker.undo()

    print("\nClient: Once more!\n")
    caretaker.undo()
