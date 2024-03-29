﻿using System.Reflection;

namespace CodingChallenge
{
    internal partial class Program
    {
        public static bool debug = false;
        static void Main(string[] args)
        {
            InfoStore infoStore = new InfoStore();
            createCatalysts(infoStore);
            createReagents(infoStore);
            Console.Title = "The marvellous Menagerie";
            DialogueHandler.Intro();

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();

                if (debug) { Console.WriteLine("[Debug enabled]\n"); }
                Console.WriteLine($"\n\n Ahead of me lies a vast field of enclosures and habitats. To my right a short gray building.\n" +
                    $" A rusted sign hangs over the door to this building. It's barely legible but I think it says The Facility.\n");
                Console.WriteLine($"\n  Where should I go next?\n\n 1 - The Menagerie\n 2 - The Facility \n 3 - Leave");
                string? input = Console.ReadLine();
                int selection = 1;
                if (Int32.TryParse(input, out int i)) { selection = Math.Clamp(i, 1, 3); }

                if (debug) { Console.WriteLine($"{selection}"); }
                if (debug) Console.ReadKey();

                switch (selection)
                {
                    case 1:
                        Menagerie.TheMenagerie(infoStore);
                        break;

                    case 2:
                        Facility.CreatureCreator(infoStore);
                        break;

                    case 3:
                        Console.WriteLine($"\n    I think I will leave for now to recollect my thoughts.");
                        Console.ReadKey();
                        return;
                }             
            }
        }

        
    }
}