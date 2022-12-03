using System.Runtime.InteropServices;

namespace CodingChallenge
{
	internal partial class DialogueHandler
	{

        internal static void Intro()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine($"\n  {DateTime.Today.ToString("dd-MM-1972")}\n\n Several years ago I discovered a series of reports filed away at an undisclosed location.\n\n" +
                               " At first it appeared as if these reports were merely categorising animals and their behaviours, \n" +
                               " mundane research data such as lists of species, their habitat and diet.\n" +
                               " However looking closely at the records there were, abnormalities. Reports that didn't appear to make sense,\n" +
                               " descriptions that didn't seem to match any documented animal.\n" +
                               " Indeed these attributes appeared, unnatural, one might even say otherwordly.\n\n");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(" \n\n At first I assumed they were a hoax. a fanciful fabrication from a tired mind.\n" +
                               " Yet the descriptions were so, vivid, so specific.\n" +
                               " I began to doubt my skepticism. I tried to put the reports out of my head, to concentrate on my other research,\n" +
                               " but my mind was always drawn back. There was something about it, something unnerving I had to know.\n\n" +
                               " After much thought and lost sleep, I decided that I would track where these reports came from, to confirm\n" +
                               " or deny, the existence of such miraculous beings.\n" +
                               " Through a series of events I was able to gather information on where these reports were originally created\n" +
                               " and finally, no more than a few days ago, nestled in the valley of an unmarked island in the South Pacific,\n" +
                               " I finally found it.\n\n" +
                               " The facility I coined, the Marvellous Menagarie.");
            Console.ReadKey();
        }

        internal static void Tutorial()
        {
            Console.Clear();
            Console.WriteLine("\n  With this equipment I should be able to create my own creatures.\n");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n\n I should take note not to use up too much of the liquid in the tanks as I'm unsure how I can procure more.\n\n" +
                               " First I should insert a catalyst, I should be careful what I choose as this will affect the core of my efforts\n" +
                               " and form the basis for my creature.\n" +
                               " Secondly I should adjust the valves in a way that result in a combined increase of pressure in the gauges,\n" +
                               " I should make sure not to increase the pressure too high.\n" +
                               " Lastly when I feel that the configuration is correct I should pull the lever to start the machine processing.");
            Console.ReadKey();
        }

    }
}
