using System;

namespace AbstractFactoryExample {
    
    // Abstract Product B
    public interface ICheckbox { 
        void Render();
    }

    // Concrete Factory Product B1
    public class LightCheckbox : ICheckbox // ProductB1
    {
        public void Render()
        {
            Console.WriteLine("Rendering Light Checkbox");
        }
    }

    // Concrete Factory Product B2
    public class DarkCheckbox : ICheckbox // ProductB2
    {
        public void Render()
        {
            Console.WriteLine("Rendering Dark Checkbox");
        }
    }
}