using System;
using System.Threading;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Simulation main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            bool qPressed = false;
            Console.WriteLine("Hello, Ants!");
            Colony colony = new Colony(15);
            colony.GenerateAnts(3, 3, 3);

            bool loop = true;

            while (loop)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        if (qPressed)
                            Environment.Exit(1);
                        
                        colony.Update();
                        break;
                    case ConsoleKey.Q:
                        qPressed = true;
                        break;
                    default:
                        qPressed = false;
                        break;
                }
            }
        }
    }
}
