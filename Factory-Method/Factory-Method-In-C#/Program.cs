using System;
using System.Collections.Generic; 
using Factory;

namespace Factory {
    public class FactoryDemo {
        static void Main(string[] args) {

            // You can now create an animal by only passing it's type
            Producer.AddAnimal("Cat");
            Producer.AddAnimal("Cat");
            Producer.AddAnimal("Dog");
            Producer.AddAnimal("Cat");

            // Print the whole list
            foreach (IAnimal animal in Producer.animals) {
                animal.MakeNoise();
            }
        }
    }
}
