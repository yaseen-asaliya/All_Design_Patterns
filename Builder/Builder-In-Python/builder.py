from abc import ABC, abstractmethod

# It provides a flexible way to construct complex objects step by step

class Car:
    """Final Goal (Product)"""
    def __init__(self):
        self.engine = None
        self.wheels = None
        self.color = None

    def __str__(self):
        return f"Car [Engine: {self.engine}, Wheels: {self.wheels}, Color: {self.color}]"

class ICarBuilder(ABC):
    """Builder Interface"""
    @abstractmethod
    def set_engine(self, engine):
        pass

    @abstractmethod
    def set_wheels(self, wheels):
        pass

    @abstractmethod
    def set_color(self, color):
        pass

    @abstractmethod
    def get_car(self):
        pass


class CarBuilder(ICarBuilder):
    """Concrete Builder"""
    def __init__(self):
        self._car = Car()

    def set_engine(self, engine):
        self._car.engine = engine

    def set_wheels(self, wheels):
        self._car.wheels = wheels

    def set_color(self, color):
        self._car.color = color

    def get_car(self):
        return self._car


class CarDirector:
    """Director (Who order/excute the steps to produce the final object)"""
    def __init__(self, builder):
        self._builder = builder

    def build_sports_car(self):
        self._builder.set_engine("V8")
        self._builder.set_wheels(4)
        self._builder.set_color("Red")

    def build_suv(self):
        self._builder.set_engine("V6")
        self._builder.set_wheels(4)
        self._builder.set_color("Black")

if __name__ == "__main__":
    builder = CarBuilder()
    director = CarDirector(builder)

    # Build a Sports Car
    director.build_sports_car()
    sports_car = builder.get_car()
    print(sports_car)

    # Build an SUV
    director.build_suv()
    suv = builder.get_car()
    print(suv)