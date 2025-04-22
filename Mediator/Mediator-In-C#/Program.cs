using System;
using System.Collections.Generic;

/*
    The Mediator pattern centralizes communication between objects to reduce direct dependencies. 
    Instead of objects talking to each other directly, they communicate through a mediator.

*/
// Mediator Interface
interface IAirTrafficControl
{
    void RegisterAircraft(Aircraft aircraft);
    void SendMessage(string message, Aircraft sender);
}

// Abstract Colleague
abstract class Aircraft
{
    protected IAirTrafficControl _controlTower;
    public string Name { get; private set; }

    public Aircraft(string name, IAirTrafficControl controlTower)
    {
        Name = name;
        _controlTower = controlTower;
        _controlTower.RegisterAircraft(this);
    }

    public abstract void Receive(string message);
    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends message: {message}");
        _controlTower.SendMessage(message, this);
    }
}

// Concrete Mediator
class AirTrafficControlTower : IAirTrafficControl
{
    private readonly List<Aircraft> _aircrafts = new List<Aircraft>();

    public void RegisterAircraft(Aircraft aircraft)
    {
        if (!_aircrafts.Contains(aircraft))
            _aircrafts.Add(aircraft);
    }

    public void SendMessage(string message, Aircraft sender)
    {
        foreach (var aircraft in _aircrafts)
        {
            if (aircraft != sender)
                aircraft.Receive($"From {sender.Name}: {message}");
        }
    }
}

// Concrete Colleagues (Planes)
class LuffyPlane : Aircraft
{
    public LuffyPlane(IAirTrafficControl controlTower) 
        : base("Luffy", controlTower) {}

    public override void Receive(string message)
    {
        Console.WriteLine($" Luffy received: {message}");
    }
}

class ZoroPlane : Aircraft
{
    public ZoroPlane(IAirTrafficControl controlTower) 
        : base("Zoro", controlTower) {}

    public override void Receive(string message)
    {
        Console.WriteLine($" Zoro received: {message}");
    }
}

class NamiPlane : Aircraft
{
    public NamiPlane(IAirTrafficControl controlTower) 
        : base("Nami", controlTower) {}

    public override void Receive(string message)
    {
        Console.WriteLine($" Nami received: {message}");
    }
}

// 🧪 Main
class Program
{
    static void Main()
    {
        IAirTrafficControl atcTower = new AirTrafficControlTower();

        var luffy = new LuffyPlane(atcTower);
        var zoro = new ZoroPlane(atcTower);
        var nami = new NamiPlane(atcTower);

        luffy.Send("I'm ready to land!");
        Console.WriteLine();
        zoro.Send("I'm taking off, clear the runway!");
    }
}
