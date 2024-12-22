from zope.interface import implementer
from .animal import IAnimal

@implementer(IAnimal)
class Cat:
    # Add Cat's attributes here...

    def make_noise(self):
        # Cat noise implementation 
        print("Cat noise....")
