from Factory.cat_class import Cat
from Factory.dog_class import Dog

class Producer:
    animals = []

    @staticmethod
    def add_animal(animal_type: str):

        if animal_type == "Cat":
            Producer.animals.append(Cat())
        elif animal_type == "Dog":
            Producer.animals.append(Dog())

    

