from abc import ABC, abstractmethod

"""
    Goal: Defines a grammar for a language and provides an interpreter to interpret sentences of that language.
    Use case: When you need to evaluate or interpret expressions based on a set of rules.
    It's like building a small language and an engine to parse and understand it.
"""

class Expression(ABC):
    @abstractmethod
    def interpret(self) -> int:
        pass

class NumberExpression(Expression):
    def __init__(self, number: int):
        self.number = number

    def interpret(self) -> int:
        return self.number

class AddExpression(Expression):
    def __init__(self, left: Expression, right: Expression):
        self.left = left
        self.right = right

    def interpret(self) -> int:
        return self.left.interpret() + self.right.interpret()

if __name__ == "__main__":
    # Represents: (5 + 10)
    left = NumberExpression(5)
    right = NumberExpression(10)

    addition = AddExpression(left, right)

    print(f"Result: {addition.interpret()}")  # Output: 15
