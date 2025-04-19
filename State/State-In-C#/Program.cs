using System;

namespace MultiPageFormStatePattern
{
    public interface IFormState
    {
        void Next(FormContext context);
        void Previous(FormContext context);
        void Display(FormContext context);
    }

    public class PageOneState : IFormState
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public void Next(FormContext context)
        {
            context.SetState(context.PageTwo);
        }

        public void Previous(FormContext context)
        {
            Console.WriteLine("Already on the first page.");
        }

        public void Display(FormContext context)
        {
            Console.WriteLine("Page 1: Personal Info");
            Console.Write("Full Name: ");
            FullName = Console.ReadLine();
            Console.Write("Age: ");
            int.TryParse(Console.ReadLine(), out int age);
            Age = age;

            Console.WriteLine($"Saved: {FullName}, Age: {Age}");
        }
    }

    public class PageTwoState : IFormState
    {
        public string Email { get; set; }
        public string Phone { get; set; }

        public void Next(FormContext context)
        {
            context.SetState(context.PageThree);
        }

        public void Previous(FormContext context)
        {
            context.SetState(context.PageOne);
        }

        public void Display(FormContext context)
        {
            Console.WriteLine("Page 2: Contact Info");
            Console.Write("Email: ");
            Email = Console.ReadLine();
            Console.Write("Phone: ");
            Phone = Console.ReadLine();

            Console.WriteLine($"Saved: {Email}, {Phone}");
        }
    }

    public class PageThreeState : IFormState
    {
        public string Country { get; set; }
        public string City { get; set; }

        public void Next(FormContext context)
        {
            context.SetState(context.PageFour);
        }

        public void Previous(FormContext context)
        {
            context.SetState(context.PageTwo);
        }

        public void Display(FormContext context)
        {
            Console.WriteLine("Page 3: Address Info");
            Console.Write("Country: ");
            Country = Console.ReadLine();
            Console.Write("City: ");
            City = Console.ReadLine();

            Console.WriteLine($"Saved: {Country}, {City}");
        }
    }

    public class PageFourState : IFormState
    {
        public void Next(FormContext context)
        {
            Console.WriteLine("Submitting form...");
        }

        public void Previous(FormContext context)
        {
            context.SetState(context.PageThree);
        }

        public void Display(FormContext context)
        {
            Console.WriteLine("Page 4: Summary / Submit");

            var p1 = context.PageOne;
            var p2 = context.PageTwo;
            var p3 = context.PageThree;

            Console.WriteLine($"Name: {p1.FullName}, Age: {p1.Age}");
            Console.WriteLine($"Email: {p2.Email}, Phone: {p2.Phone}");
            Console.WriteLine($"Country: {p3.Country}, City: {p3.City}");

            Console.WriteLine("\nPress Enter to submit...");
            Console.ReadLine();
            Console.WriteLine("Form Submitted!");
        }
    }

    public class FormContext
    {
        private IFormState _currentState;

        public PageOneState PageOne { get; }
        public PageTwoState PageTwo { get; }
        public PageThreeState PageThree { get; }
        public PageFourState PageFour { get; }

        public FormContext()
        {
            PageOne = new PageOneState();
            PageTwo = new PageTwoState();
            PageThree = new PageThreeState();
            PageFour = new PageFourState();

            _currentState = PageOne;
        }

        public void SetState(IFormState state)
        {
            _currentState = state;
        }

        public void Next() => _currentState.Next(this);
        public void Previous() => _currentState.Previous(this);
        public void Display() => _currentState.Display(this);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var form = new FormContext();

            while (true)
            {
                form.Display();

                Console.Write("\nEnter action (next / prev / exit): ");
                string input = Console.ReadLine()?.ToLower();

                if (input == "next") form.Next();
                else if (input == "prev") form.Previous();
                else if (input == "exit") break;

                Console.WriteLine("\n-----------------------------\n");
            }

            Console.WriteLine("Form closed.");
        }
    }
}
