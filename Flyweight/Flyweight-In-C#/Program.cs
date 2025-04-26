using System;
using System.Collections.Generic;

/*
    The Flyweight Design Pattern is a structural pattern used to reduce memory usage when you have a large number of similar objects. 
    It shares common data between those objects instead of storing it individually in each one.
*/
namespace FlyweightDemo {
    public class CharacterFlyweight
    {
        private readonly string _font;
        private readonly int _fontSize;

        public CharacterFlyweight(string font, int fontSize)
        {
            _font = font;
            _fontSize = fontSize;
        }

        public void Render(char character, int x, int y)
        {
            Console.WriteLine($"Rendering '{character}' at ({x},{y}) with font {_font}, size {_fontSize}");
        }
    }

    public class FlyweightFactory
    {
        private readonly Dictionary<string, CharacterFlyweight> _flyweights = new();

        public CharacterFlyweight GetFlyweight(string font, int fontSize)
        {
            string key = $"{font}_{fontSize}";
            if (!_flyweights.ContainsKey(key))
            {
                _flyweights[key] = new CharacterFlyweight(font, fontSize);
            }
            return _flyweights[key];
        }
    }

    class Program
    {
        static void Main()
        {
            var factory = new FlyweightFactory();

            var flyweight1 = factory.GetFlyweight("Arial", 12);
            flyweight1.Render('A', 10, 20);

            var flyweight2 = factory.GetFlyweight("Arial", 12);
            flyweight2.Render('B', 11, 20);

            var flyweight3 = factory.GetFlyweight("Courier New", 14);
            flyweight3.Render('C', 12, 20);

            var flyweight4 = factory.GetFlyweight("Arial", 12);
            flyweight4.Render('D', 13, 20);
        }
    }

}
