import copy

class Prototype:
    """
    Used to create new objects by cloning an existing object (the prototype) 
    rather than instantiating new objects from scratch.
    This is useful when object creation is expensive or complex.
    """
    def clone(self):
        """Shallow copy method"""
        pass

    def deep_clone(self):
        """Deep copy method"""
        pass


class Engine:
    def __init__(self, engine_type):
        self.type = engine_type

    def __str__(self):
        return self.type


class Car(Prototype):
    def __init__(self, make, model, year, engine):
        self.make = make
        self.model = model
        self.year = year
        self.engine = engine

    def clone(self):
        """Shallow copy method"""
        return copy.copy(self)  # Creates a shallow copy (nested objects are shared)

    def deep_clone(self):
        """Deep copy method"""
        return copy.deepcopy(self)  # Creates a deep copy (nested objects are also copied)

    def __str__(self):
        return f"{self.year} {self.make} {self.model} with {self.engine} engine"


# Demonstration
if __name__ == "__main__":
    # Original object
    original_car = Car("Toyota", "Corolla", 2022, Engine("Hybrid"))
    print("Original Car:", original_car)

    # Perform shallow copy
    shallow_car = original_car.clone()
    shallow_car.engine.type = "Electric"  # Modifying the nested object
    print("Shallow Copy Car:", shallow_car)
    print("Original Car after shallow copy modification:", original_car)

    # Perform deep copy
    deep_car = original_car.deep_clone()
    deep_car.engine.type = "Diesel"  # Modifying the nested object
    print("Deep Copy Car:", deep_car)
    print("Original Car after deep copy modification:", original_car)
