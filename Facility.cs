using System.Text;
using static CodingChallenge.Program;

namespace CodingChallenge
{
	partial class Facility
	{
        internal static void CreatureCreator(InfoStore infoStore)
        {

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Let's create a Creature.\n");

            string[] amountDescription = new string[] { "exhusted", "poor", "middling", "adaquate", "plentiful", "brimming" };
            foreach (Reagent reagent in infoStore.reagent)
            {
                int descriptionValue = 0;
                if (reagent.quantity < 5) { descriptionValue = 0; }
                else if (reagent.quantity == 255) { descriptionValue = 5; }
                else
                {
                    descriptionValue = (int)Math.Ceiling((decimal)(reagent.quantity * 100 / 255) / 25);
                    //Console.WriteLine($"{Math.Ceiling((decimal)(reagent.quantity * 100 / 255) / 25)}");

                }
                Console.WriteLine($"   My levels of {reagent.name} are {amountDescription[descriptionValue]}.");
            }

            int temperatrus = infoStore.reagent[0].quantity;
            int irascribilis = infoStore.reagent[0].quantity;
            int intelligentia = infoStore.reagent[0].quantity;
            int chaos = infoStore.reagent[0].quantity;

            Console.WriteLine("\n I should choose which catalyst to set:\n");
            for (int j = 0; j < infoStore.catalysts.Count; j++)
            {
                Console.WriteLine($"{j + 1} - {infoStore.catalysts[j].name}");
            }

            int choice = 0;
            string input = Console.ReadLine() ?? "1";
            if (Int32.TryParse(input, out int i)) { choice = Math.Abs(i) - 1; } //abs to remove negative numbers and break choice, -1 to match 0 base

            if (choice > infoStore.catalysts.Count) { choice = 0; };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nI have chosen, {infoStore.catalysts[choice].name}.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            string[] steps = new String[] { "Turn the left Valve", "Turn the middle Valve", "Turn the right valve", "Inject Chaos", "Pull the lever" };
            int loopChoice = 0;
            int x = Math.Clamp((infoStore.catalysts[choice].dataMap[0, 3] * 40), 1, 255);
            int y = Math.Clamp((infoStore.catalysts[choice].dataMap[1, 3] * 40), 1, 255);
            int z = Math.Clamp((infoStore.catalysts[choice].dataMap[2, 3] * 40), 1, 255);

            do
            {
                Console.Clear();
                Console.WriteLine("\n current levels:");
                Console.WriteLine(" ===============");
                foreach (Reagent reagent in infoStore.reagent)
                {
                    Console.WriteLine($" {reagent.name}: {reagent.quantity * 100 / 255}%");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n [");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{infoStore.catalysts[choice].name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"] has been inserted into the socket.\n");



                if (debug) { Console.WriteLine($"DEBUG: x{x},y{y},z{z}"); }

                drawGauge(x, 'α');
                drawGauge(y, 'β');
                drawGauge(z, 'δ');

                Console.WriteLine($"\n\n In front of me I see three gauges. Under these gauges I can see three valves. To my right there is a lever.\n I should select my next step:\n    ");

                loopChoice = ConsoleHelper.MultipleChoice(false, true, 24, steps);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n\nI have chosen to {steps[loopChoice]}.");

                Console.ReadKey();


                (int a, int b, int c) values = setGauges(x, y, z, loopChoice, choice, infoStore);
                (x, y, z) = values;

            } while (loopChoice != 4);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The machine engages...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            int catalystType = infoStore.catalysts[choice].dataMap[3, 3];
            if (choice != 0) { infoStore.catalysts.Remove(infoStore.catalysts[choice]); }

            Console.Clear();
            if (debug) { Console.WriteLine($"DEBUG This creature is {x}, {y}, {z}, {catalystType}"); }
            Creature creature = new Creature(x, y, z, catalystType);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n    ...A creature emerges from the machine.\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($" this creature most closely resembles the {creature.species} animal class.\n It is {creature.diet} and has a {creature.behaviour} sleeping pattern.");
            Console.WriteLine($" Its {creature.sizes} {creature.colour} {creature.bodyParts} appears {creature.textures} and {creature.health}.");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\n Should I keep this creature?");
                input = Console.ReadLine() ?? "no";
                if (input.ToLower() == "yes")
                {
                    Menagerie.nameCreature(creature);
                    infoStore.storedCreatures.Add(creature);
                    Console.WriteLine($" I will move this creature to the menagerie.");
                    Console.ReadKey();
                    loop = !loop;
                }
                else
                {
                    Console.WriteLine($" I don't want to keep this creature.\n Should I will release it?");
                    input = Console.ReadLine() ?? "no";
                    if (input.ToLower() == "yes")
                    {
                        Console.WriteLine($" I have released this creature into the wild.\n     ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"The creature will remember you.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ReadKey();
                        infoStore.wildCreatures.Add(creature);
                        loop = !loop;
                    }

                }
            }
        }

        private static void drawGauge(int reading, char label)
        {
            int gaugeLength = 10; //control length of gauge and determines possible slider positions
            int gaugeTuning = 10; //control increments to test slider on
            string slider = "[::]";
            string bar = "====";

            int sum = reading * 100 / 255;
            if (sum <= 0) { sum = 1; }

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= gaugeLength; ++i)
            {
                if ((sum >= i * gaugeTuning - (gaugeTuning - 1)) && (sum <= i * gaugeTuning))
                    sb.Append(slider);
                else
                    sb.Append(bar);
            }
            Console.WriteLine($"\n    I [{sb.ToString()}] II {label}");
        }

        private static (int x, int y, int z) setGauges(int x, int y, int z, int loopChoice, int choice, InfoStore infoStore)
        {
            if (loopChoice > 3) { return (x, y, z); }

            if (infoStore.reagent[loopChoice].quantity < 5)
            {
                Console.WriteLine($"no more {infoStore.reagent[loopChoice].name} can be released.");
                Console.ReadKey();
                return (x, y, z);
            }
            else
            {
                x = Math.Clamp(x + (infoStore.catalysts[choice].dataMap[loopChoice, 0]) * 20, 1, 255);
                y = Math.Clamp(y + (infoStore.catalysts[choice].dataMap[loopChoice, 1]) * 20, 1, 255);
                z = Math.Clamp(z + (infoStore.catalysts[choice].dataMap[loopChoice, 2]) * 20, 1, 255);
                infoStore.reagent[loopChoice].quantity -= 5;
                return (x, y, z);
            }
        }
    }
}
