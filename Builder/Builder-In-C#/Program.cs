using System;

namespace BuilderExample {

    // It provides a flexible way to construct complex objects step by step

    class Demo {

        // Final Goal (Product)
        public class Car
        {
            public string Engine { get; set; }
            public int Wheels { get; set; }
            public string Color { get; set; }

            public override string ToString()
            {
                return $"Car [Engine: {Engine}, Wheels: {Wheels}, Color: {Color}]";
            }
        }
        
        // Builder interface 
        public interface ICarBuilder {
            void SetEngine(string engine);
            void SetWheels(int wheels);
            void SetColor(string color);
            Car GetCar();
        }

        // Builder Concrete class
        public class CarBuilder : ICarBuilder {
            private Car _car = new Car();

            public void SetEngine(string engine) {
                _car.Engine = engine;
            }

            public void SetWheels(int wheels) {
                _car.Wheels = wheels;
            }
            public void SetColor(string color) {
                _car.Color = color;
            }

            public Car GetCar() {
                return _car;
            }
        }

        // The Director (Who order/excute the steps to produce the final object)
        public class CarDirector
        {
            private readonly ICarBuilder _builder;

            public CarDirector(ICarBuilder builder) {
                _builder = builder;
            }

            public void BuildSportsCar(){
                _builder.SetEngine("V8");
                _builder.SetWheels(4);
                _builder.SetColor("Red");
            }

            public void BuildSUV()
            {
                _builder.SetEngine("V6");
                _builder.SetWheels(4);
                _builder.SetColor("Black");
            }

            // Add your custome implmentation here

        }


        static void Main(string[] args) {
            ICarBuilder builder = new CarBuilder();
            CarDirector director = new CarDirector(builder);

            // Build a Sports Car
            director.BuildSportsCar();
            Car sportsCar = builder.GetCar();
            Console.WriteLine(sportsCar);

            // Build an SUV
            director.BuildSUV();
            Car suv = builder.GetCar();
            Console.WriteLine(suv);

        }
    }

}