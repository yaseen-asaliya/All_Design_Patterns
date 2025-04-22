from abc import ABC, abstractmethod

# Mediator Interface
class IAirTrafficControl(ABC):
    @abstractmethod
    def register_aircraft(self, aircraft):
        pass

    @abstractmethod
    def send_message(self, message, sender):
        pass

# Abstract Colleague
class Aircraft(ABC):
    def __init__(self, name, control_tower: IAirTrafficControl):
        self.name = name
        self._control_tower = control_tower
        self._control_tower.register_aircraft(self)

    @abstractmethod
    def receive(self, message):
        pass

    def send(self, message):
        print(f"{self.name} sends message: {message}")
        self._control_tower.send_message(message, self)

# Concrete Mediator
class AirTrafficControlTower(IAirTrafficControl):
    def __init__(self):
        self._aircrafts = []

    def register_aircraft(self, aircraft):
        if aircraft not in self._aircrafts:
            self._aircrafts.append(aircraft)

    def send_message(self, message, sender):
        for aircraft in self._aircrafts:
            if aircraft != sender:
                aircraft.receive(f"From {sender.name}: {message}")

# Concrete Colleagues
class LuffyPlane(Aircraft):
    def __init__(self, control_tower):
        super().__init__("Luffy", control_tower)

    def receive(self, message):
        print(f" Luffy received: {message}")

class ZoroPlane(Aircraft):
    def __init__(self, control_tower):
        super().__init__("Zoro", control_tower)

    def receive(self, message):
        print(f" Zoro received: {message}")

class NamiPlane(Aircraft):
    def __init__(self, control_tower):
        super().__init__("Nami", control_tower)

    def receive(self, message):
        print(f" Nami received: {message}")

# 🧪 Main
if __name__ == "__main__":
    atc_tower = AirTrafficControlTower()

    luffy = LuffyPlane(atc_tower)
    zoro = ZoroPlane(atc_tower)
    nami = NamiPlane(atc_tower)

    luffy.send("I'm ready to land!")
    print()
    zoro.send("I'm taking off, clear the runway!")
