using System;
using System.Threading;

namespace UpdateFake
{
    class Program
    {
        static bool running = true;
        static bool paused = false;
        static bool canceled = false;
        static double timeMinutes = 5; // valor padrão caso usuário não informe

        static void Main(string[] args)
        {
            Header();
            Setup();
            Run();
            Finish();
        }

        static void Header()
        {
            Console.Clear();
            Console.WriteLine("Microsoft Windows [Version 10.0.19045.2965]");
            Console.WriteLine("(c) Microsoft Corporation. All rights reserved.\n");

            Console.WriteLine("C:\\Windows\\System32>wuauclt /detectnow\n");
        }

        static void Setup()
        {
            Console.WriteLine("Checking for updates...");
            Thread.Sleep(1500);
            Console.WriteLine("1 update found.");
            Thread.Sleep(1200);

            Console.Write("\nTime available for download (minutes): ");
            timeMinutes = double.Parse(Console.ReadLine()!);

            Console.WriteLine("\nDownloading update 1 of 1: Cumulative Update for Windows 10 Version 21H2 (KB5006670)");
            Console.WriteLine("Starting download...\n");
            Thread.Sleep(1000);
        }

        static void Run()
        {
            int progress = 0;
            const int total = 100;
            const int barSize = 40;

            var random = new Random();
            string status = "Downloading";

            int totalTimeMs = (int)(timeMinutes * 60 * 1000); // tempo total convertido para ms

            Console.WriteLine("Controls: P = Pause | R = Restart | E = Exit\n");

            while (running && progress <= total)
            {
                // INPUT
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.P)
                        paused = !paused;

                    if (key == ConsoleKey.R)
                    {
                        progress = 0;
                        paused = false;
                        Console.Clear();
                        Header();
                        Setup();
                        totalTimeMs = (int)(timeMinutes * 60 * 1000);
                    }

                    if (key == ConsoleKey.E)
                    {
                        canceled = true;
                        running = false;
                        break;
                    }
                }

                if (paused)
                {
                    Console.Write("\r[PAUSED]                                        ");
                    Thread.Sleep(300);
                    continue;
                }

                // status fake
                if (progress > 70) status = "Installing";
                if (progress > 90) status = "Finalizing";

                int speed = random.Next(1, 4);
                progress += speed;
                if (progress > total)
                    progress = total;

                int filled = progress * barSize / total;
                string bar = new string('█', filled).PadRight(barSize, '░');

                Console.Write($"\r{status,-12} [{bar}] {progress,3}%");

                // sair automaticamente quando chegar a 100%
                if (progress >= total)
                {
                    running = false;
                    break;
                }

                // Sleep proporcional ao tempo informado
                Thread.Sleep(totalTimeMs / total);
            }
        }

        static void Finish()
        {
            Console.WriteLine("\n");

            if (canceled)
            {
                Console.WriteLine("Update canceled by user.");
            }
            else
            {
                Console.WriteLine("Update completed successfully.");
                Console.WriteLine("System is up to date.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
