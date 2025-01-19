class Car:
    """Final Goal (Product)"""
    def __init__(self):
        self.Engine = None
        self.Wheels = None
        self.Color = None
        self.GPS = None
        self.Sunroof = None

    def __str__(self):
        return (f"Car [Engine: {self.Engine}, Wheels: {self.Wheels}, "
                f"Color: {self.Color}, GPS: {self.GPS}, Sunroof: {self.Sunroof}]")


class ICarBuilder:
    """Builder interface"""
    def set_engine(self, engine):
        pass

    def set_wheels(self, wheels):
        pass

    def set_color(self, color):
        pass

    def get_car(self):
        pass


class CarBuilder(ICarBuilder):
    """Concrete implementation of the builder"""
    def __init__(self):
        self._car = Car()

    def set_engine(self, engine):
        self._car.Engine = engine

    def set_wheels(self, wheels):
        self._car.Wheels = wheels

    def set_color(self, color):
        self._car.Color = color

    def get_car(self):
        return self._car


class CarDirector:
    """The Director"""
    def __init__(self, builder):
        self._builder = builder

    def build_car(self, car, *attributes):
        """
        Dynamically build a car by assigning attributes.
        Attributes are passed as tuples: (attribute_name, value).
        """
        for attribute, value in attributes:
            if hasattr(car, attribute):
                # Automatically convert types where needed
                field_type = type(getattr(car, attribute))
                converted_value = field_type(value) if field_type != type(None) else value
                setattr(car, attribute, converted_value)
            else:
                print(f"Unknown or read-only attribute: {attribute}")


# Main function
if __name__ == "__main__":
    builder = CarBuilder()
    director = CarDirector(builder)

    # Build a car dynamically with custom attributes
    custom_car = Car()
    director.build_car(custom_car,
                       ("Engine", "V12"),
                       ("Wheels", "6"),
                       ("Color", "Blue"),
                       ("GPS", "True"),
                       ("Sunroof", "True"))
    print(custom_car)
