using System;

﻿namespace DesignPatterns
{
    class Demo
    {
        static void Main(string[] args)
        {
            // Single singleton
            Singleton obj = Singleton.GetInstance(); // no matter how much this line invoked, it will always return the same object
            obj.attr1 = 1; 
            Console.WriteLine(obj.attr1); 

            // Singleton with registery 
            ISingleton singleton = SingletonRegistry.Lookup("SingletonA");
            singleton?.DoWork();

            singleton = SingletonRegistry.Lookup("SingletonB");
            singleton?.DoWork(); 
        }
    }
}
