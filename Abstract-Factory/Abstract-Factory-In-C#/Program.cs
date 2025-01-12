namespace AbstractFactoryExample {
    
    class Program
    {
        static void Main(string[] args)
        {
            // Directly create factory and objects
            IThemeFactory lightThemeFactory = new LightThemeFactory(); // Create product in Light theme 
            IThemeFactory darkThemeFactory = new DarkThemeFactory(); // Create product in Dark theme 

            // Use Light Theme
            Console.WriteLine("Using Light Theme:");
            IButton lightButton = lightThemeFactory.CreateButton();
            ICheckbox lightCheckbox = lightThemeFactory.CreateCheckbox();
            lightButton.Render();
            lightCheckbox.Render();

            // Use Dark Theme
            Console.WriteLine("\nUsing Dark Theme:");
            IButton darkButton = darkThemeFactory.CreateButton();
            ICheckbox darkCheckbox = darkThemeFactory.CreateCheckbox();
            darkButton.Render();
            darkCheckbox.Render();
        }
    }

}