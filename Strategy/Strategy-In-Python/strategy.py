# The Strategy Pattern is a behavioral design pattern that allows selecting an algorithm's behavior at runtime.
# It enables defining a family of algorithms, encapsulating each one in a separate class, and making them interchangeable.

# Benefits:
# - When you have multiple algorithms that can be used interchangeably (change at runtime).
# - When you want to avoid using multiple if-else or switch statements.
# - When a class's behavior should be easily changed without modifying its code.


class ISortStrategy():
    def sort(self, array: list[int]) -> None:
        pass

class BubbleSort(ISortStrategy):
    def sort(self, array: list[int]) -> None:
        array.sort()  # Simulating Bubble Sort

class QuickSort(ISortStrategy):
    def sort(self, array: list[int]) -> None:
        array.sort()  # Simulating Quick Sort

class SortContext:
    def __init__(self):
        self._sort_strategy: ISortStrategy | None = None

    def set_sort_strategy(self, sort_strategy: ISortStrategy) -> None:
        self._sort_strategy = sort_strategy

    def execute_sort(self, array: list[int]) -> None:
        if self._sort_strategy is None:
            print("No sorting strategy selected.")
            return
        self._sort_strategy.sort(array)

if __name__ == "__main__":
    context = SortContext()
    numbers = [5, 2, 9, 1, 6]

    # Using Bubble Sort
    context.set_sort_strategy(BubbleSort())
    context.execute_sort(numbers)
    print("Sorted Array:", numbers)

    # Using Quick Sort
    numbers = [5, 2, 9, 1, 6]  # Reset array
    context.set_sort_strategy(QuickSort())
    context.execute_sort(numbers)
    print("Sorted Array:", numbers)
