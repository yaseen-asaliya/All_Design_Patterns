/* 
The Strategy Pattern is a behavioral design pattern that allows selecting an algorithm's behavior at runtime. 
It enables defining a family of algorithms, encapsulating each one in a separate class, and making them interchangeable.

Bendifits:
- When you have multiple algorithms that can be used interchangeably (change at run time).
- When you want to avoid using multiple if-else or switch statements.
- When a class's behavior should be easily changed without modifying its code.

*/

namespace StrategyDemo
{
    public interface ISortStrategy
    {
        void Sort(int[] array);
    }

    public class BubbleSort : ISortStrategy
    {
        public void Sort(int[] array)
        {
            Array.Sort(array);  // Simulating Bubble Sort
        }
    }

    public class QuickSort : ISortStrategy
    {
        public void Sort(int[] array)
        {
            Array.Sort(array);  // Simulating Quick Sort
        }
    }

    public class SortContext
    {
        private ISortStrategy _sortStrategy;

        public void SetSortStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void ExecuteSort(int[] array)
        {
            _sortStrategy.Sort(array);
        }
    }

    class Program
    {
        static void Main()
        {
            SortContext context = new SortContext();
            int[] numbers = { 5, 2, 9, 1, 6 };

            // Using Bubble Sort
            context.SetSortStrategy(new BubbleSort());
            context.ExecuteSort(numbers);

            // Using Quick Sort
            context.SetSortStrategy(new QuickSort());
            context.ExecuteSort(numbers);
        }
    }

}


