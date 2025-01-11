from zope.interface import implementer
from .animal import IAnimal

@implementer(IAnimal)
class Dog:
    # Add Dog's attributes here...

    def make_noise(self):
        # Dog noise implementation 
        print("Dog noise....")
