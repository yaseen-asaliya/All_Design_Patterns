using System;

namespace DecoratorDemo
{
    /*
        The Decorator Design Pattern allows you to dynamically add new behavior to objects without altering their structure. 
        It works by wrapping the original object with a series of decorator classes, each adding its own functionality
    */
    
    public interface Pizza 
    {
        string getDescription();
        double getCost();
    }

    public class PlainPizza : Pizza 
    {
        public string getDescription() 
        {
            return "Thin Dough";
        }

        public double getCost()
        {
            return 4.00;
        }
    }

    public abstract class ToppingDecorator : Pizza 
    {
        protected Pizza tempPizza;

        public ToppingDecorator(Pizza newPizza) 
        {
            this.tempPizza = newPizza;       
        }

        public virtual string getDescription() 
        {
            return tempPizza.getDescription();
        }

        public virtual double getCost()
        {
            return tempPizza.getCost();
        }
    }

    public class Mozzarella : ToppingDecorator  
    {
        public Mozzarella(Pizza newPizza) : base(newPizza)
        {
        }

        public override string getDescription() 
        {
            return tempPizza.getDescription() + ", Mozzarella";
        }

        public override double getCost()
        {
            return tempPizza.getCost() + 3.00;
        }
    }

    public class TomatoSauce : ToppingDecorator  
    {
        public TomatoSauce(Pizza newPizza) : base(newPizza)
        {
        }

        public override string getDescription() 
        {
            return tempPizza.getDescription() + ", Tomato Sauce";
        }

        public override double getCost()
        {
            return tempPizza.getCost() + 0.50;
        }
    }

    class Demo {
        public static void Main(string[] args) 
        {
            Pizza pizza = new TomatoSauce(new Mozzarella(new PlainPizza()));

            Console.WriteLine(pizza.getDescription());
            Console.WriteLine(pizza.getCost());
        }
    }
}
