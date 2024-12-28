using System;
using FacadeDemo;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Projector projector = new Projector();
            Amplifier amplifier = new Amplifier();
            DVDPlayer dvdPlayer = new DVDPlayer();
            Lights lights = new Lights();

            // Create the facade
            HomeTheaterFacade homeTheater = new HomeTheaterFacade(projector, amplifier, dvdPlayer, lights);

            // Use the facade
            homeTheater.WatchMovie("Inception");
            homeTheater.EndMovie();
        }
    }
}
