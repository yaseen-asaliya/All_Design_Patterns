using System;

namespace AbstractFactoryExample {

    // Abstract Product A
    public interface IButton {
        void Render();
    }

    // Concrete Factory Product A1
    public class LightButton : IButton // ProductA1
    {
        public void Render()
        {
            Console.WriteLine("Rendering Light Button");
        }
    }

    // Concrete Factory Product A2
    public class DarkButton : IButton // ProductA2
    {
        public void Render()
        {
            Console.WriteLine("Rendering Dark Button");
        }
    }
}