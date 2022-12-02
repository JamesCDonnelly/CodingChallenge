using System;
using System.Text;

namespace CodingChallenge
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
           
            InfoStore infoStore = new InfoStore();
            createCatalysts(infoStore);
            Console.Title = "The marvellous Menagerie";
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            int temperatrus = 255;
            int irascribilis = 255;
            int intelligentia = 255;
            int chaos = 255;


            (int x, int y, int z, int m) creatureTraits = CreatureCreator(temperatrus, irascribilis, intelligentia, chaos, infoStore);

            while (true)
            {

                Console.Clear();
                Console.WriteLine($"DEBUG This creature is {creatureTraits.x}, {creatureTraits.y}, {creatureTraits.z}, {creatureTraits.m}"); //TODO remove
                Creature creature = new Creature(creatureTraits.x, creatureTraits.y, creatureTraits.z, creatureTraits.m);
                Console.WriteLine($"({infoStore.storedCreatures.Count}) creatures stored.");



                Console.WriteLine($"this creature most closely resembles the {creature.species} animal class.\nIt is a {creature.diet} and has a {creature.behaviour} sleeping pattern.");
                Console.WriteLine($"Its {creature.sizes} {creature.colour} {creature.bodyParts} look {creature.textures} and {creature.health}.");
                Console.WriteLine("\nDo you wish to keep this creature?");
                String choice = Console.ReadLine() ?? "no";
                if (choice == "yes") {
                    nameCreature(creature);
                    infoStore.storedCreatures.Add(creature);
                    Console.WriteLine($"The creature has been stored");
                }
                else { infoStore.wildCreatures.Add(creature); }
            }
        }


        private static (int x, int y, int z, int m) CreatureCreator(int temperatrus, int irascribilis, int intelligentia, int chaos, InfoStore infoStore)
        {
            /*infoStore.catalysts.Add("rock");
            foreach(string name in infoStore.catalysts)
            {
                Console.WriteLine($"{name}");
            }*/


            Console.WriteLine("Let's create a Creature.\n");
            Console.WriteLine("Your levels of temperatrus are plentiful\n" +
                                "Your levels of irascibilis are plentiful\n" +
                                "Your levels of intelligentia are plentiful\n" +
                                "You have several quantities of chaos left.");



            Console.WriteLine("\nchoose which catalyst to set:\n");
            for (int j = 0; j < infoStore.catalysts.Count; j++)
            {
                Console.WriteLine($"{j + 1} - {infoStore.catalysts[j].name}");
            }

            int choice = 1;
            string input = Console.ReadLine() ?? "1";
            if (Int32.TryParse(input, out int i)) { choice = i - 1; }
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\nYou have chosen, {infoStore.catalysts[choice].name}.");
            

            /*
            switch (choice)
            {
                case 2:
                    Console.WriteLine("\nYou have chosen, a weathered grey slate pebble");
                    break;
                case 3:
                    Console.WriteLine("\nYou have chosen, a sea-worn bleached bone");
                    break;
                case 4:
                    Console.WriteLine("\nYou have chosen, a charred Oak bark strip");
                    break;
                default:
                    Console.WriteLine("\nYou have chosen, nothing");
                    break;
            }
            */
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();

            string[] steps = new String[] { "Turn left Value", "Turn middle Valve", "Turn right valve", "Inject Chaos", "Complete" };
            int loopChoice = 0;
            int x = (int)(infoStore.catalysts[choice].dataMap[0, 3] * 40);
            int y = (int)(infoStore.catalysts[choice].dataMap[1, 3] * 40);
            int z = (int)(infoStore.catalysts[choice].dataMap[2, 3] * 40);

            do
            {
                Console.Clear();
                Console.WriteLine("\n current levels:");
                Console.WriteLine($" temperatrus: {temperatrus * 100 / 255}%");
                Console.WriteLine($" irascribilis: {irascribilis * 100 / 255}%");
                Console.WriteLine($" intelligentia: {intelligentia * 100 / 255}%");
                Console.WriteLine($" chaos: {chaos * 100 / 255}%\n");

                Console.WriteLine($" [{infoStore.catalysts[choice].name}] has been inserted into the socket.\n");



                Console.WriteLine($"DEBUG: x{x},y{y},z{z}"); //TODO remove

                drawGauge(x, 'α');
                drawGauge(y, 'β');
                drawGauge(z, 'δ');

                Console.WriteLine($"\n\nIn front of you are three gauges. Under the gauges you see three valves.\nEnter your next step:\n");
                //Console.WriteLine($"Turn left valve, turn middle valve, turn right valve, inject chaos.\n");



                loopChoice = ConsoleHelper.MultipleChoice(false, true, steps);


                Console.WriteLine($"\n\nYou have chosen to {steps[loopChoice]}.");

                Console.WriteLine($"DEBUG {infoStore.catalysts[choice].dataMap[0, 0]}");  //TODO remove
                Console.WriteLine($"DEBUG {infoStore.catalysts[choice].dataMap[0, 1]}");  //TODO remove
                Console.WriteLine($"DEBUG {infoStore.catalysts[choice].dataMap[0, 2]}");  //TODO remove

                Console.ReadKey();


                if (loopChoice == 0)
                {  
                    x = Math.Clamp(x + (infoStore.catalysts[choice].dataMap[0, 0]) * 20, 0, 255);
                    y = Math.Clamp(y + (infoStore.catalysts[choice].dataMap[0, 1]) * 20, 0, 255);
                    z = Math.Clamp(z + (infoStore.catalysts[choice].dataMap[0, 2]) * 20, 0, 255);
                    temperatrus -= 5;
                }

                if (loopChoice == 1)
                {
                    x = Math.Clamp(x + (infoStore.catalysts[choice].dataMap[1, 0]) * 20, 0, 255);
                    y = Math.Clamp(y + (infoStore.catalysts[choice].dataMap[1, 1]) * 20, 0, 255);
                    z = Math.Clamp(z + (infoStore.catalysts[choice].dataMap[1, 2]) * 20, 0, 255);
                    irascribilis -= 5;
                }

                if (loopChoice == 2)
                {
                    x = Math.Clamp(x + (infoStore.catalysts[choice].dataMap[2, 0]) * 20, 0, 255);
                    y = Math.Clamp(y + (infoStore.catalysts[choice].dataMap[2, 1]) * 20, 0, 255);
                    z = Math.Clamp(z + (infoStore.catalysts[choice].dataMap[2, 2]) * 20, 0, 255);
                    intelligentia -= 5;
                }

                if (loopChoice == 3)
                {
                    x = Math.Clamp(x + (infoStore.catalysts[choice].dataMap[3, 0]) * 20, 0, 255);
                    y = Math.Clamp(y + (infoStore.catalysts[choice].dataMap[3, 1]) * 20, 0, 255);
                    z = Math.Clamp(z + (infoStore.catalysts[choice].dataMap[3, 2]) * 20, 0, 255);
                    chaos -= 5;
                }
            } while (loopChoice != 4);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The machine engages...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            int catalystType = infoStore.catalysts[choice].dataMap[3, 3];
            if (choice != 0) { infoStore.catalysts.Remove(infoStore.catalysts[choice]); }
            return (x,y,z, catalystType);

        }

        private static void drawGauge(int reading, char label)
        {
            string slider = "[::]";
            string bar = "====";

            int sum = reading * 100 / 255;
            if (sum <= 0) { sum = 1; }

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 5; ++i)
            {
                /*
                int A = reading * 100 / 255;
                int B =   i * 20 - 19;

                int C = reading * 100 / 255;
                int D = i * 20;
                
                Console.WriteLine($"{A} {B} : {C} {D}");
                */
                if ((sum >= i * 20 - 19) && (sum <= i * 20))
                    sb.Append(slider);
                else
                    sb.Append(bar);
            }

            Console.WriteLine($"    I [{sb.ToString()}] II {label}");
        }



        private static void nameCreature(Creature creature)
        {
            Console.WriteLine("would you like to name this creature?");
            String choice = Console.ReadLine() ?? "no";
            if (choice == "yes")
            {
                Console.WriteLine("Please provide a name");
                string name = Console.ReadLine() ?? "creature";
                Console.WriteLine($"Are you happy to name this creature {name}?");
                String confirmation = Console.ReadLine() ?? "no";
                if (confirmation == "yes") { creature.nameCreature(name); }
                else { nameCreature(creature); }
            }
        }
        public class Catalyst
        {
            public string name { get; } = "missingNo";
            public string description { get; } = "desc";
            public int[,] dataMap { get; }

            public Catalyst(string name, string description, int[,] dataMap)
            {
                this.name = name;
                this.description = description;
                this.dataMap = dataMap;
            }

        }

        public static void createCatalysts(InfoStore infoStore)
        {
            string name = "nothing";
            string description = "The absence of anything.";

            int[,] dataMap = new int[4, 4] {    { 1, -2, -3, 0},  //1st column controls x gauge, 2nd controls y gauge, 3rd controls z gauge
                                                { -2, 1, -2, 0},  //bottom row is for chaos, 4th column are starting points for all three gauges.
                                                { -3, -2, 1, 0},  //3,3 is an int to determine max type
                                                { 1, 1, 1, 0} };  // (note the 4x4 grid is not related to math calculation, it's just a coincidence.

            Catalyst catalyst = new Catalyst(name, description, dataMap);

            infoStore.catalysts.Add(catalyst); 
            
            name = "a weathered grey slate pebble";
            description = "The stone is smooth and cold to the touch.";

            dataMap = new int[4,4] {    { 1, -2, -2, 0},
                                        { 0, 1, -2, 1},
                                        { -1, -2, 1, 0},
                                        { 1, 1, 1, 1  } };

            catalyst = new Catalyst(name, description, dataMap);

            infoStore.catalysts.Add(catalyst);

            name = "a sea-worn bleached bone";
            description = "It is surprisingly light and heavily worn with a coarse texture.";

            dataMap = new int[4, 4] {    { 1, 0, -2, 0},
                                        { -2, 1, -2, 0},
                                        { -1, 0, 1, 1},
                                        { 1, 1, 1, 1  } };

            catalyst = new Catalyst(name, description, dataMap);

            infoStore.catalysts.Add(catalyst);

            name = "a charred Oak bark strip";
            description = "The charred end is sooty and crumbly.";

            dataMap = new int[4, 4] {    { 1, 0, 0, 1},
                                        { -1, 1, -1, 0},
                                        { 0, 0, 1, 0},
                                        { 1, 1, 1, 1  } };

            catalyst = new Catalyst(name, description, dataMap);

            infoStore.catalysts.Add(catalyst);
        }

        public class InfoStore
        {
            public List<Creature> storedCreatures { get; set; }
            public List<Creature> wildCreatures { get; set; }

            public List<Catalyst> catalysts  {get; set;}

            public InfoStore()
            {
                storedCreatures = new List<Creature>();
                wildCreatures = new List<Creature>();
                catalysts = new List<Catalyst>();
                //string[] initialCatalysts = new string[] { "nothing", "a weathered grey slate pebble", "a sea-worn bleached bone", "a charred Oak bark strip" };
                //catalysts.AddRange(initialCatalysts);
            }
        }

        





    }

}