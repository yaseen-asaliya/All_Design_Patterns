class Subject:
    def __init__(self):
        # List of observer functions to notify
        self._observers = []
        self._state = None

    @property
    def state(self):
        return self._state

    @state.setter
    def state(self, value):
        self._state = value
        self._notify_observers()  # Notify all observers when state changes

    def attach(self, observer):
        """Attach an observer function to the subject."""
        self._observers.append(observer)

    def detach(self, observer):
        """Detach an observer function from the subject."""
        self._observers.remove(observer)

    def _notify_observers(self):
        """Notify all attached observers about the state change."""
        for observer in self._observers:
            observer(self._state)


# Observer functions
def observer_a(state):
    # write your custom implementation here 
    print(f"Observer A: State changed to {state}")


def observer_b(state):
    # write your custom implementation here 
    print(f"Observer B: State changed to {state}")


if __name__ == "__main__":
    subject = Subject()

    # Attach observer functions to the subject
    subject.attach(observer_a)
    subject.attach(observer_b)

    # Change the state to trigger notifications
    subject.state = 10  # it's gonna print: 
                        # Observer A: State changed to 10
                        # Observer B: State changed to 10

    subject.state = 20  # it's gonna print:
                        # Observer A: State changed to 20
                        # Observer B: State changed to 20

    # Detach Observer B
    subject.detach(observer_b)

    subject.state = 30  # it's gonna print: 
                        # Observer A: State changed to 30
