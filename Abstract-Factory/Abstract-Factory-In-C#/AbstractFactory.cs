using System;

namespace AbstractFactoryExample {

    // Abstract Factory
    public interface IThemeFactory // AbstractFactory
    {
        IButton CreateButton();  // CreateProductA
        ICheckbox CreateCheckbox();  // CreateProductB
    }

    // Concrete Factory 1
    public class LightThemeFactory : IThemeFactory // // create all products in light
    {
        public IButton CreateButton()
        {
            return new LightButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new LightCheckbox();
        }
    }

    // Concrete Factory 2
    public class DarkThemeFactory : IThemeFactory // create all products in dark
    {
        public IButton CreateButton()
        {
            return new DarkButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new DarkCheckbox();
        }
    }

}