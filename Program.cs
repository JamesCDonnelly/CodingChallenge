using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using static CodingChallenge.Program;

namespace CodingChallenge
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            InfoStore infoStore = new InfoStore();
            createCatalysts(infoStore);
            createReagents(infoStore);
            Console.Title = "The marvellous Menagerie";

            //int temperatrus = 255;
            //int irascribilis = 255;
            //int intelligentia = 255;
            //int chaos = 255;

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();

                Console.WriteLine($"\nWhere should I go next?\n 1 - The Menagerie\n 2 - The Facility \n 3 - Leave");
                string? input = Console.ReadLine();
                int selection = 1;
                if (Int32.TryParse(input, out int i)) { selection = Math.Clamp(i, 1, 3); }

                switch(selection)
                {
                    case 1:
                        Menagerie(infoStore);
                        break;

                    case 2:
                        //CreatureCreator(temperatrus, irascribilis, intelligentia, chaos, infoStore);
                        CreatureCreator(infoStore);
                        break;

                    case 3:
                        Console.WriteLine($"I think I will leave for now to recollect my thoughts.");
                        Console.ReadKey();
                        return;
                }
                //Console.WriteLine($"{selection}");
                //Console.ReadKey();

                //(int x, int y, int z, int m) creatureTraits = CreatureCreator(temperatrus, irascribilis, intelligentia, chaos, infoStore);
                
            }
        }

        private static void Menagerie(InfoStore infoStore)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            if (infoStore.storedCreatures.Count == 0) { Console.WriteLine($"Currently there are no creatures stored at the menagerie."); Console.ReadKey(); return; }
            else
            {
                if (infoStore.storedCreatures.Count == 1) { Console.WriteLine($"Currently there is {infoStore.storedCreatures.Count} creature stored at the menagerie."); }
                else { Console.WriteLine($"Currently there are {infoStore.storedCreatures.Count} creatures stored at the menagerie."); }
                Console.ReadKey();
                viewCreatures(infoStore);
            }
        }

        private static void viewCreatures(InfoStore infoStore)
        {
            int index = 0;
            bool visit = true;
            while (visit)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();

                //Console.WriteLine($"DEBUG {index}");
                //Console.WriteLine($"DEBUG storecreatures count {infoStore.storedCreatures.Count}");

                Creature creature = infoStore.storedCreatures[index];
                Console.Write($"[PEN: {index + 1}]");
                Console.Write($"\nThis creature is {creature.creatureName}.\n\n This creature most closely resembles species from the {creature.species} animal class.\n" +
                                  $" It is {creature.diet} and has a {creature.behaviour} sleeping pattern.\n" +
                                  $" Its {creature.sizes} {creature.colour} {creature.bodyParts} appears {creature.textures} and {creature.health}.\n\n" +
                                  $" It can detect other presences using its strong sense of {creature.senses}.");
                Random rnd = new Random();
                if (rnd.Next(1, 7) == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" It can detect you now.\n\n   ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($" It calls out with a {creature.noises} {creature.cries}.\n\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else
                {

                    Console.WriteLine($"\n The creature cannot detect you right now, you should come back later.\n\n");
                }

                string[] steps = new String[] { "Next", "Previous", "Rename", "Leave" };
                int loopChoice = 0;
                loopChoice = ConsoleHelper.MultipleChoice(true, true, 14, steps);

                switch (loopChoice)
                {
                    case 0:
                        index++;
                        if (index > infoStore.storedCreatures.Count - 1) { index = 0; }
                        break;
                    case 1:
                        index--;
                        if (index < 0) { index = infoStore.storedCreatures.Count-1; }
                        break;
                    case 2:
                        Console.Clear();
                        nameCreature(creature);
                        break;
                    default:
                        visit = !visit;
                        break;
                }
            }

        }

        private static void CreatureCreator(/*int temperatrus, int irascribilis, int intelligentia, int chaos, */InfoStore infoStore)
        {
     

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            /*infoStore.catalysts.Add("rock");
            foreach(string name in infoStore.catalysts)
            {
                Console.WriteLine($"{name}");
            }*/


            Console.WriteLine("Let's create a Creature.\n");

            string[] amountDescription = new string[] {"exhusted", "poor", "middling", "adaquate", "plentiful", "brimming"};
            foreach(Reagent reagent in infoStore.reagent)
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

            /*
            Console.WriteLine($"   My levels of temperatrus are {amountDescription[descriptionValue]}.\n" +
                                $"   My levels of irascibilis are {amountDescription[descriptionValue]}.\n" +
                                $"   My levels of intelligentia are {amountDescription[descriptionValue]}.\n" +
                                $"   My levels of chaos are {amountDescription[descriptionValue]}.\n");

            */

            Console.WriteLine("\n I should choose which catalyst to set:\n");
            for (int j = 0; j < infoStore.catalysts.Count; j++)
            {
                Console.WriteLine($"{j + 1} - {infoStore.catalysts[j].name}");
            }

            int choice = 0;
            string input = Console.ReadLine() ?? "1";
            if (Int32.TryParse(input, out int i)) { choice = Math.Abs(i)-1; } //abs to remove negative numbers and break choice, -1 to match 0 base


            if (choice > infoStore.catalysts.Count) { choice = 0;  };

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\nI have chosen, {infoStore.catalysts[choice].name}.");
            

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
                //Console.WriteLine($" temperatrus: {temperatrus * 100 / 255}%");
                //Console.WriteLine($" irascribilis: {irascribilis * 100 / 255}%");
                //Console.WriteLine($" intelligentia: {intelligentia * 100 / 255}%");
                //Console.WriteLine($" chaos: {chaos * 100 / 255}%\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n [");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{infoStore.catalysts[choice].name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"] has been inserted into the socket.\n");



                //Console.WriteLine($"DEBUG: x{x},y{y},z{z}"); //TODO remove

                drawGauge(x, 'α');
                drawGauge(y, 'β');
                drawGauge(z, 'δ');

                Console.WriteLine($"\n\n In front of me I see three gauges. Under these gauges I can see three valves. To my right there is a lever.\n I should select my next step:\n    ");
                //Console.WriteLine($"Turn left valve, turn middle valve, turn right valve, inject chaos.\n");



                loopChoice = ConsoleHelper.MultipleChoice(false, true, 24, steps);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n\nI have chosen to {steps[loopChoice]}.");

                Console.ReadKey();

                
                // Work in Progress
                //int a = 0;
                //int b = 0;
                //int c = 0;
                //int chemical = 0;
                (int a, int b, int c) values = setGauges(x, y, z, loopChoice, choice, infoStore);
                (x, y, z) = values;
                //temperatrus = chemical;
                /*/

                //TODO revise into single method

                if (loopChoice == 0)
                {
                    if (temperatrus < 5) { Console.WriteLine($"no more temperatrus can be released."); Console.ReadKey(); }
                    else
                    {
                        x = Math.Clamp(x + (infoStore.catalysts[choice].dataMap[0, 0]) * 20, 1, 255);
                        y = Math.Clamp(y + (infoStore.catalysts[choice].dataMap[0, 1]) * 20, 1, 255);
                        z = Math.Clamp(z + (infoStore.catalysts[choice].dataMap[0, 2]) * 20, 1, 255);
                        temperatrus -= 5;
                    }
                }

                if (loopChoice == 1)
                {
                    x = Math.Clamp(x + (infoStore.catalysts[choice].dataMap[1, 0]) * 20, 1, 255);
                    y = Math.Clamp(y + (infoStore.catalysts[choice].dataMap[1, 1]) * 20, 1, 255);
                    z = Math.Clamp(z + (infoStore.catalysts[choice].dataMap[1, 2]) * 20, 1, 255);
                    irascribilis -= 5;
                }

                if (loopChoice == 2)
                {
                    x = Math.Clamp(x + (infoStore.catalysts[choice].dataMap[2, 0]) * 20, 1, 255);
                    y = Math.Clamp(y + (infoStore.catalysts[choice].dataMap[2, 1]) * 20, 1, 255);
                    z = Math.Clamp(z + (infoStore.catalysts[choice].dataMap[2, 2]) * 20, 1, 255);
                    intelligentia -= 5;
                }

                if (loopChoice == 3)
                {
                    x = Math.Clamp(x + (infoStore.catalysts[choice].dataMap[3, 0]) * 20, 1, 255);
                    y = Math.Clamp(y + (infoStore.catalysts[choice].dataMap[3, 1]) * 20, 1, 255);
                    z = Math.Clamp(z + (infoStore.catalysts[choice].dataMap[3, 2]) * 20, 1, 255);
                    chaos -= 5;
                }
                /*/

            } while (loopChoice != 4);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The machine engages...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            int catalystType = infoStore.catalysts[choice].dataMap[3, 3];
            if (choice != 0) { infoStore.catalysts.Remove(infoStore.catalysts[choice]); }
            //return (x,y,z, catalystType);

            //while (true)
            //{

            Console.Clear();
            //Console.WriteLine($"DEBUG This creature is {x}, {y}, {z}, {catalystType}"); //TODO remove
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
                    nameCreature(creature);
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
                        loop=!loop;
                    }

                }
            }
           // }
        }

        private static (int x, int y, int z) setGauges(int x, int y, int z, int loopChoice, int choice, InfoStore infoStore)
        {
            if (loopChoice > 3) { return (x, y, z); }
            //int chemical = infoStore.reagent[loopChoice].quantity;

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
                /*
                int A = reading * 100 / 255;
                int B =   i * 20 - 19;

                int C = reading * 100 / 255;
                int D = i * 20;
                
                Console.WriteLine($"{A} {B} : {C} {D}");
                */
                if ((sum >= i * gaugeTuning - ( gaugeTuning - 1)) && (sum <= i * gaugeTuning))
                    sb.Append(slider);
                else
                    sb.Append(bar);
            }
            Console.WriteLine($"\n    I [{sb.ToString()}] II {label}");
        }



        private static void nameCreature(Creature creature)
        {
            Console.WriteLine(" Should I name this creature?");
            String choice = Console.ReadLine() ?? "no";
            if (choice.ToLower() == "yes")
            {
                Console.WriteLine(" I need to provide a name");
                string name = Console.ReadLine() ?? "creature";
                Console.WriteLine($" Is {name} a good name?");
                String confirmation = Console.ReadLine() ?? "no";
                if (confirmation.ToLower() == "yes") { creature.creatureName = name; }
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

        public class Reagent
        {
            public string name { get; } = "unknown reagent";
            public int quantity { get; set; }

            public Reagent(string name, int quantity)
            {
                this.name = name;
                this.quantity = quantity;
            }


            
        }


        public static void createReagents(InfoStore infoStore) //(int temperatrus, int irascribilis, int intelligentia, int chaos, InfoStore infoStore)
        {
            string name = "Temperatrus";
            int quantity = 255;
            Reagent reagent = new Reagent(name, quantity);
            infoStore.reagent.Add(reagent);

            name = "Irascribilis";
            quantity = 255;
            reagent = new Reagent(name, quantity);
            infoStore.reagent.Add(reagent);

            name = "Intelligentia";
            quantity = 255;
            reagent = new Reagent(name, quantity);
            infoStore.reagent.Add(reagent);

            name = "Chaos";
            quantity = 255;
            reagent = new Reagent(name, quantity);
            infoStore.reagent.Add(reagent);

        }

        public static void createCatalysts(InfoStore infoStore)
        {
            string name = "nothing";
            string description = "The absence of anything.";

            int[,] dataMap = new int[4, 4] {    { 1, -2, -3, 0},  //1st column controls x gauge, 2nd controls y gauge, 3rd controls z gauge
                                                { -2, 1, -2, 0},  //bottom row is for chaos, 4th column are starting points for all three gauges.
                                                { -3, -2, 1, 0},  //(3,3) is an int to determine max type
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

            public List<Reagent> reagent { get; set; }

            public InfoStore()
            {
                reagent= new List<Reagent>();
                storedCreatures = new List<Creature>();
                wildCreatures = new List<Creature>();
                catalysts = new List<Catalyst>();
                //string[] initialCatalysts = new string[] { "nothing", "a weathered grey slate pebble", "a sea-worn bleached bone", "a charred Oak bark strip" };
                //catalysts.AddRange(initialCatalysts);
            }
        }

        





    }

}