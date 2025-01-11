import zope.interface

class IAnimal(zope.interface.Interface): # define IAnimal interface 
    def make_noise(self):
        pass

