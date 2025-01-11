using System.Collections.Generic;

namespace Factory {
    public class Producer {
        // A list contains all type of animal with different sub-classes
        public static List<IAnimal> animals = new List<IAnimal>();
        
        public static void AddAnimal(string type) {
            if(type == "Cat"){
                animals.Add(new Cat());
            }
            else if(type == "Dog") {
                animals.Add(new Dog());
            }
        }

    }
}