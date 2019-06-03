using System;

namespace Droid.Scheduler.Agent
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Droid scheduler agent.");
            Clock.Start();
            while (true) { }
        }
    }
}
