using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">>>> Welcome to the Stopwatch <<<<");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            var stopwatch = new StopwatchTimer();
            stopwatch.Setup();
            stopwatch.Run();
        }
    }

    class StopwatchTimer
    {
        private int initialTime;
        private int endTime;
        private int currentTime;
        private int step;

        private bool paused;
        private bool running;

        public void Setup()
        {
            Console.Clear();

            initialTime = ReadTime("Enter the initial time (ex: 10s or 1m): ");
            endTime = ReadTime("Enter the end time (ex: 30s or 2m): ");

            Console.Write("Press C for ascending or D for descending: ");
            string mode = Console.ReadLine()!.Trim().ToUpper();

            if (mode != "C" && mode != "D")
            {
                Console.WriteLine("Invalid option. Use C or D.");
                Setup();
                return;
            }

            // 🔑 CORREÇÃO DEFINITIVA
            if (mode == "C")
            {
                currentTime = Math.Min(initialTime, endTime);
                endTime = Math.Max(initialTime, endTime);
                step = 1;
            }
            else
            {
                currentTime = Math.Max(initialTime, endTime);
                endTime = Math.Min(initialTime, endTime);
                step = -1;
            }

            paused = false;
            running = true;
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Controls: P = Pause | R = Resume | S = Restart | E = Exit\n");

            while (running && currentTime != endTime)
            {
                HandleInput();

                if (!paused)
                {
                    Console.WriteLine($"Time: {currentTime} seconds");
                    currentTime += step;
                }

                Thread.Sleep(1000);
            }

            if (running)
            {
                Console.WriteLine($"Time: {endTime} seconds");
                Console.WriteLine("Stopwatch finished!");
            }
        }

        private void HandleInput()
        {
            if (!Console.KeyAvailable) return;

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.P:
                    paused = true;
                    Console.WriteLine("Paused");
                    break;

                case ConsoleKey.R:
                    paused = false;
                    Console.WriteLine("Resumed");
                    break;

                case ConsoleKey.S:
                    Console.WriteLine("Restarting...");
                    Setup();
                    Console.Clear();
                    Console.WriteLine("Controls: P = Pause | R = Resume | S = Restart | E = Exit\n");
                    break;

                case ConsoleKey.E:
                    Console.WriteLine("Exiting...");
                    running = false;
                    break;
            }
        }

        private int ReadTime(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
                {
                    Console.WriteLine("Invalid format. Use 10s or 2m.");
                    continue;
                }

                char unit = input[^1];

                if (unit != 's' && unit != 'm')
                {
                    Console.WriteLine("Invalid unit. Use 's' or 'm'.");
                    continue;
                }

                if (!int.TryParse(input[..^1], out int value))
                {
                    Console.WriteLine("Invalid number.");
                    continue;
                }

                return unit == 'm' ? value * 60 : value;
            }
        }
    }
}
