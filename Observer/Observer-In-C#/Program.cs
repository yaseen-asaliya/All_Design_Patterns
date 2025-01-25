﻿using System;

namespace ObserverExample {

    public class Subject
    {
        public event Action<int> StateChanged; // Event to notify observers

        private int state;

        public int State
        {
            get => state;
            set
            {
                state = value;
                OnStateChanged(state); // Will call this (2)
            }
        }

        protected virtual void OnStateChanged(int state)
        {
            StateChanged?.Invoke(state); // Notify all subscribers
        }
    }

    class Program
    {
        static void Main()
        {
            Subject subject = new Subject();

            // Attach observer functions to the subject
            subject.StateChanged += (state) => Console.WriteLine($"Observer A: State changed to {state}");
            subject.StateChanged += (state) => Console.WriteLine($"Observer B: State changed to {state}");

            subject.State = 10; // Notify observers (1)
            subject.State = 20;
        }
    }

}