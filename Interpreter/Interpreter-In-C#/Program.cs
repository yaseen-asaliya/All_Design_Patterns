using System;

/* 
    Goal: Defines a grammar for a language and provides an interpreter to interpret sentences of that language.
    Use case: When you need to evaluate or interpret expressions based on a set of rules.
    It's like building a small language and an engine to parse and understand it.

*/
namespace InterpretDemo {
    public interface IExpression
    {
        int Interpret();
    }

    public class NumberExpression : IExpression
    {
        private readonly int _number;

        public NumberExpression(int number)
        {
            _number = number;
        }

        public int Interpret()
        {
            return _number;
        }
    }

    public class AddExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public AddExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret()
        {
            return _left.Interpret() + _right.Interpret();
        }
    }

    class Program
    {
        static void Main()
        {
            // Represents: (5 + 10)
            IExpression left = new NumberExpression(5);
            IExpression right = new NumberExpression(10);

            IExpression addition = new AddExpression(left, right);

            Console.WriteLine($"Result: {addition.Interpret()}"); // Output: 15
        }
    }

}
