using System;

namespace PrototypeExample
{
    /*
    It used to create new objects by cloning an existing object the prototype rather than instantiating new objects from scratch. 
    This is useful when object creation is expensive or complex.
    */

    interface IPrototype
    {
        IPrototype Clone(); // Shallow copy method
        IPrototype DeepClone(); // Deep copy method
    }

    class Car : IPrototype
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Engine Engine { get; set; } // Nested object for demonstration (To apply deep copy)

        // Shallow copy method
        public IPrototype Clone() 
        {
            return (IPrototype)MemberwiseClone(); // It will return an object has the address of the current object (any changes to the new object will reflect to the)
        }

        // Deep copy method
        public IPrototype DeepClone()
        {
            Car deepCopy = (Car)this.MemberwiseClone();
            deepCopy.Engine = new Engine { Type = this.Engine.Type }; // It will return a new object (any changes to the new object will not reflect to the)
            return deepCopy;
        }

        public override string ToString()
        {
            return $"{Year} {Make} {Model} with {Engine.Type} engine";
        }
    }

    class Engine
    {
        public string Type { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Car originalCar = new Car
            {
                Make = "Toyota",
                Model = "Corolla",
                Year = 2022,
                Engine = new Engine { Type = "Hybrid" }
            };
            Console.WriteLine("Original Car: " + originalCar);

            Car shallowCar = (Car)originalCar.Clone();
            shallowCar.Engine.Type = "Electric"; // Modifying the nested object
            Console.WriteLine("Shallow Copy Car: " + shallowCar);
            Console.WriteLine("Original Car after shallow copy modification: " + originalCar);

            Car deepCar = (Car)originalCar.DeepClone();
            deepCar.Engine.Type = "Diesel"; // Modifying the nested object
            Console.WriteLine("Deep Copy Car: " + deepCar);
            Console.WriteLine("Original Car after deep copy modification: " + originalCar);
        }
    }
}
