using System;

namespace BuilderExample
{
    class Demo
    {
        // Final Goal (Product)
        public class Car
        {
            public string Engine { get; set; }
            public int Wheels { get; set; }
            public string Color { get; set; }
            public bool GPS { get; set; }
            public bool Sunroof { get; set; }

            public override string ToString()
            {
                return $"Car [Engine: {Engine}, Wheels: {Wheels}, Color: {Color}, GPS: {GPS}, Sunroof: {Sunroof}]";
            }
        }

        // Builder interface
        public interface ICarBuilder
        {
            void SetEngine(string engine);
            void SetWheels(int wheels);
            void SetColor(string color);
            Car GetCar();
        }

        // Builder Concrete class
        public class CarBuilder : ICarBuilder
        {
            private Car _car = new Car();

            public void SetEngine(string engine)
            {
                _car.Engine = engine;
            }

            public void SetWheels(int wheels)
            {
                _car.Wheels = wheels;
            }

            public void SetColor(string color)
            {
                _car.Color = color;
            }

            public Car GetCar()
            {
                return _car;
            }
        }

        // The Director
        public class CarDirector
        {
            private readonly ICarBuilder _builder;

            public CarDirector(ICarBuilder builder)
            {
                _builder = builder;
            }

            // Dynamically building a car
            public void BuildCar(Car car, params (string Attribute, string Value)[] attributes)
            {
                var carType = car.GetType();

                foreach (var (attribute, value) in attributes)
                {
                    var property = carType.GetProperty(attribute);

                    if (property != null && property.CanWrite)
                    {
                        var convertedValue = Convert.ChangeType(value, property.PropertyType);
                        property.SetValue(car, convertedValue);
                    }
                    else
                    {
                        Console.WriteLine($"Unknown or read-only attribute: {attribute}");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ICarBuilder builder = new CarBuilder();
            CarDirector director = new CarDirector(builder);

            // Build a car dynamically with custom attributes
            var customCar = new Car();
            director.BuildCar(customCar,
                ("Engine", "V12"),
                ("Wheels", "6"),
                ("Color", "Blue"),
                ("GPS", "True"),
                ("Sunroof", "True")
            );
            Console.WriteLine(customCar);
        }
    }
}
