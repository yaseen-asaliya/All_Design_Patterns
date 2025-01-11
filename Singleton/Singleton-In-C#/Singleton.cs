using System;
using System.Collections.Generic;

namespace DesignPatterns
{

    // Simple Singleton implementation 
    public class Singleton
    {
        // you can add attributes here

        private static Singleton instance; // static object, so it will create only one time 

        private Singleton() 
        {
            // you can initilize attributes here
        }

        public static Singleton GetInstance() { // static get method (it will create the object first time)
            if (instance == null) 
            {
                instance = new Singleton();
            } 
            return instance;
        }
    }

    // Advance Singleton implementation (use register)
    // it's just a way to store set of singleton objects in a dictonary  

    public interface ISingleton
    {
        void DoWork(); // A method that all Singleton classes should implement
    }

   public class SingletonRegistry
    {
        private static Dictionary<string, ISingleton> _registry = new Dictionary<string, ISingleton>();

        public static void Register(string name, ISingleton instance)
        {
            if (!_registry.ContainsKey(name))
            {
                _registry[name] = instance;
            }
        }

        public static ISingleton Lookup(string name)
        {
            if (_registry.ContainsKey(name))
            {
                return _registry[name];
            }
            return null;
        }
    }

    public class SingletonA : ISingleton
    {
        // you can add attributes here

        public static SingletonA Instance { get; private set; } = new SingletonA();

        private SingletonA()
        {
            SingletonRegistry.Register("SingletonA", this); // Register the instance by name
        }

        public void DoWork()
        {
            Console.WriteLine("SingletonA is doing work.");
        }
    }

    public class SingletonB : ISingleton
    {
        // you can add attributes here
        
        public static SingletonB Instance { get; private set; } = new SingletonB();

        private SingletonB()
        {
            SingletonRegistry.Register("SingletonB", this); // Register the instance by name
        }

        public void DoWork()
        {
            Console.WriteLine("SingletonB is doing work.");
        }
    }
}