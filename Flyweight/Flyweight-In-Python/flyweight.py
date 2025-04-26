"""
    The Flyweight Design Pattern is a structural pattern used to reduce memory usage when you have a large number of similar objects. 
    It shares common data between those objects instead of storing it individually in each one.
"""

class CharacterFlyweight:
    _font = None
    _size = None

    def __init__(self, font, size):
        self._font = font
        self._size = size

    def render(self, character, x, y):
        print(f"Rendering '{character}' at ({x}, {y}) with font '{self._font}' and size {self._size}.")

class FlyweightFactory:
    _flyweights = {}

    def get_flyweight(self, font, size):
        key = (font, size)
        if key not in self._flyweights:
            self._flyweights[key] = CharacterFlyweight(font, size)
        return self._flyweights[key]
    
flyweight_factory = FlyweightFactory()

flyweight_factory1 = flyweight_factory.get_flyweight("Arial", 12)
flyweight_factory1.render('A', 10, 20)
flyweight_factory2 = flyweight_factory.get_flyweight("Arial", 12)
flyweight_factory2.render('B', 30, 40)
flyweight_factory3 = flyweight_factory.get_flyweight("Times New Roman", 14)
flyweight_factory3.render('C', 50, 60)

