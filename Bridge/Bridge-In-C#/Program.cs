/*
The Bridge Design Pattern is a structural pattern that decopule (Separate) the abstraction from the implementation so that the two can vary independently.
*/

using System;

namespace BridgeExample
{
    // Top-level abstraction
    public abstract class Vehicle
    {
        protected Make make;

        public Vehicle(Make make)
        {
            this.make = make;
        }

        public void Start()
        {
            make.PerformRitual();
            make.StartCar();
        }

        public abstract bool AllowedToDrive(string person);
    }

    public abstract class Make
    {
        public abstract void PerformRitual();
        public abstract void StartCar();
    }

    /// Implementation
    public class BMW : Make
    {
        public override void PerformRitual() => Console.WriteLine("Hit the car");

        public override void StartCar()
        {
            Console.WriteLine("Fix the wiring");
            Console.WriteLine("Lube the engine");
            Console.WriteLine("Put the key in");
            Console.WriteLine("Turn the key");
        }
    }

    public class Volvo : Make
    {
        public override void PerformRitual() => Console.WriteLine("Grateful for buying a Volvo");

        public override void StartCar() => Console.WriteLine("Press button");
    }

    // Lower-level abstraction
    public class Car : Vehicle
    {
        public Car(Make make) : base(make) { }
        public override bool AllowedToDrive(string person) => person == "has license";
    }

    public class Truck : Vehicle
    {
        public Truck(Make make) : base(make) { }
        public override bool AllowedToDrive(string person) => person == "has special truck license";
    }

    class Program
    {
        static void Main()
        {
            Vehicle myCar = new Car(new Volvo());
            myCar.Start();
            Console.WriteLine($"Allowed to drive: {myCar.AllowedToDrive("has license")}");

            Vehicle myTruck = new Truck(new BMW());
            myTruck.Start();
            Console.WriteLine($"Allowed to drive: {myTruck.AllowedToDrive("no license")}");
        }
    }
}
