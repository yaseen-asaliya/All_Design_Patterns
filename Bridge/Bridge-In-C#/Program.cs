using System;

/*
The Bridge Design Pattern is a structural pattern that decouples an abstraction from its implementation so that the two can vary independently.
It is particularly useful when you have a class that could be extended in multiple ways but you want to avoid a combinatorial explosion of subclasses.
*/

namespace BridgeExample {
    // The Implementor
    public interface IDevice // Normal abstraction with TV and Radio 
    {
        void TurnOn();
        void TurnOff();
        void SetVolume(int percent);
    }

    // Concrete Implementor A
    public class TV : IDevice
    {
        // Change the implementation based on your need
        public void TurnOn() => Console.WriteLine("TV is now ON");
        public void TurnOff() => Console.WriteLine("TV is now OFF");
        public void SetVolume(int percent) => Console.WriteLine($"TV volume set to {percent}%");
    }

    // Concrete Implementor B
    public class Radio : IDevice
    {
        // Change the implementation based on your need
        public void TurnOn() => Console.WriteLine("Radio is now ON");
        public void TurnOff() => Console.WriteLine("Radio is now OFF");
        public void SetVolume(int percent) => Console.WriteLine($"Radio volume set to {percent}%");
    }

    // The Abstraction
    public abstract class RemoteControl
    {
        protected IDevice device;

        public RemoteControl(IDevice device)
        {
            this.device = device;
        }

        public void TurnOn() => device.TurnOn();
        public void TurnOff() => device.TurnOff();
    }

    // Refined Abstraction
    public class AdvancedRemoteControl : RemoteControl // Re-structure the abstraction (RemoteControl)
    {
        // Here you can modify the abstraction in a new way and taking old implmentation 

        // 1. Taking old implmentation
        public AdvancedRemoteControl(IDevice device) : base(device) { }

        // 2. Override (refined) current implmentation
        public void SetVolume(int percent)
        {
            if (percent < 0 || percent > 100)
            {
                Console.WriteLine("Volume out of range. Setting to default 50%.");
                percent = 50;
            }
            Console.WriteLine($"Setting volume to {percent}% via AdvancedRemoteControl.");
            device.SetVolume(percent);
        }

        // 3. Add new implmentation
        public void Mute()
        {
            Console.WriteLine("Muting the device.");
            device.SetVolume(0);
        }
    }

    // Client Code
    class Program
    {
        static void Main()
        {
            // Using TV with an advanced remote
            IDevice tv = new TV();
            AdvancedRemoteControl advancedRemoteForTV = new AdvancedRemoteControl(tv);
            advancedRemoteForTV.TurnOn();
            advancedRemoteForTV.SetVolume(150);
            advancedRemoteForTV.Mute();
            advancedRemoteForTV.TurnOff();

            Console.WriteLine();

            // Using Radio with an advanced remote
            IDevice radio = new Radio();
            AdvancedRemoteControl advancedRemoteForRadio = new AdvancedRemoteControl(radio);
            advancedRemoteForRadio.TurnOn();
            advancedRemoteForRadio.SetVolume(30); 
            advancedRemoteForRadio.Mute();
            advancedRemoteForRadio.TurnOff();
        }
    }

}