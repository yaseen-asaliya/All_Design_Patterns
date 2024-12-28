using System;

/*
The Facade Design Pattern is a structural pattern that provides a simplified interface to a larger body of code, 
making it easier for clients to interact with complex subsystems. It acts as a wrapper around complicated 
subsystems, providing a cleaner and more intuitive API for clients.
*/

// Subsystem Classes
namespace FacadeDemo
{
    class Projector
    {
        // Add class specifications here 
        public void On() {
            // Specific implemetation here
            Console.WriteLine("Projector is On.");
        }
        public void Off() {
            // Specific implemetation here
            Console.WriteLine("Projector is Off.");
        }
    }

    class Amplifier
    {
        // Add class specifications here 
        public void On() {
            // Specific implemetation here
            Console.WriteLine("Amplifier is On.");
        }
        public void SetVolume(int level) {
            // Specific implemetation here
            Console.WriteLine($"Amplifier volume set to {level}.");
        }
    }

    class DVDPlayer
    {
        // Add class specifications here 
        public void On() {
            // Specific implemetation here
            Console.WriteLine("DVD Player is On.");
        }
        public void Play(string movie) {
            // Specific implemetation here
            Console.WriteLine($"Playing movie: {movie}");
        }
    }

    class Lights
    {
        // Add class specifications here 
        public void Dim(int level) {
            // Specific implemetation here
            Console.WriteLine($"Lights dimmed to {level}%.");
        }
    }

    // Facade Class
    class HomeTheaterFacade
    {
        // Create subsystem components
        private Projector projector;
        private Amplifier amplifier;
        private DVDPlayer dvdPlayer;
        private Lights lights;

        public HomeTheaterFacade(Projector projector, Amplifier amplifier, DVDPlayer dvdPlayer, Lights lights)
        {
            this.projector = projector;
            this.amplifier = amplifier;
            this.dvdPlayer = dvdPlayer;
            this.lights = lights;
        }

        public void WatchMovie(string movie)
        {
            // Specific implemetation here
            Console.WriteLine("\nGet ready to watch a movie...");
            lights.Dim(20);
            projector.On();
            amplifier.On();
            amplifier.SetVolume(10);
            dvdPlayer.On();
            dvdPlayer.Play(movie);
        }

        public void EndMovie()
        {
            // Specific implemetation here
            Console.WriteLine("\nShutting down movie theater...");
            dvdPlayer.On();
            amplifier.On();
            projector.Off();
            lights.Dim(100);
        }
    }
}
