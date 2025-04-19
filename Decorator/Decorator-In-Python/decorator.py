from abc import ABC, abstractmethod

class Pizza(ABC):
    @abstractmethod
    def get_description(self) -> str:
        pass

    @abstractmethod
    def get_cost(self) -> float:
        pass

class PlainPizza(Pizza):
    def get_description(self) -> str:
        return "Thin Dough"

    def get_cost(self) -> float:
        return 4.00

class ToppingDecorator(Pizza):
    def __init__(self, new_pizza: Pizza):
        self._temp_pizza = new_pizza

    def get_description(self) -> str:
        return self._temp_pizza.get_description()

    def get_cost(self) -> float:
        return self._temp_pizza.get_cost()

class Mozzarella(ToppingDecorator):
    def get_description(self) -> str:
        return self._temp_pizza.get_description() + ", Mozzarella"

    def get_cost(self) -> float:
        return self._temp_pizza.get_cost() + 3.00

class TomatoSauce(ToppingDecorator):
    def get_description(self) -> str:
        return self._temp_pizza.get_description() + ", Tomato Sauce"

    def get_cost(self) -> float:
        return self._temp_pizza.get_cost() + 0.50

# Demo
if __name__ == "__main__":
    pizza = TomatoSauce(Mozzarella(PlainPizza()))
    print(pizza.get_description())
    print(pizza.get_cost())
