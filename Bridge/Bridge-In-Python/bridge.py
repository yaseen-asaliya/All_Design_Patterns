"""
The Bridge Design Pattern is a structural pattern that decouples an abstraction from its implementation so that the two can vary independently.
"""

from abc import ABC, abstractmethod

# Top-level abstraction
class Vehicle(ABC):
    def __init__(self, make):
        self.make = make

    def start(self):
        self.make.perform_ritual()
        self.make.start_car()

    @abstractmethod
    def allowed_to_drive(self, person):
        pass

# Implementation
class Make(ABC):
    @abstractmethod
    def perform_ritual(self):
        pass

    @abstractmethod
    def start_car(self):
        pass

class BMW(Make):
    def perform_ritual(self):
        print("Hit the car")

    def start_car(self):
        print("Fix the wiring")
        print("Lube the engine")
        print("Put the key in")
        print("Turn the key")

class Volvo(Make):
    def perform_ritual(self):
        print("Grateful for buying a Volvo")

    def start_car(self):
        print("Press button")

# Lower-level abstraction
class Car(Vehicle):
    def __init__(self, make):
        super().__init__(make)

    def allowed_to_drive(self, person):
        return person == "has license"

class Truck(Vehicle):
    def __init__(self, make):
        super().__init__(make)

    def allowed_to_drive(self, person):
        return person == "has special truck license"

# Example usage
if __name__ == "__main__":
    my_car = Car(Volvo())
    my_car.start()
    print(f"Allowed to drive: {my_car.allowed_to_drive('has license')}")

    my_truck = Truck(BMW())
    my_truck.start()
    print(f"Allowed to drive: {my_truck.allowed_to_drive('no license')}")
