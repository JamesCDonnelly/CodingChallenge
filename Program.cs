using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace CodingChallenge
{
    internal class Program
    {




        static void Main(string[] args)
        {
            StorageCollection infoStore = new StorageCollection();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            byte x = 255;
            byte y = 255;
            byte z = 255;
            byte w = 255;


            (byte x, byte y, byte z, byte w) creatureTraits = CreatureCreator(x, y, z, w, infoStore);

            while (true)
            {
                
                Console.Clear();
                Creature creature = new Creature(creatureTraits.x, creatureTraits.y, creatureTraits.z);
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


        private static (byte x, byte y, byte z, byte w) CreatureCreator(byte temperatrus, byte irascribilis, byte intelligentia, byte chaos, StorageCollection infoStore)
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
                                "Your levels of chaos are plentiful");



            Console.WriteLine("\nchoose which catalyst to set:\n");
            for (int j = 0; j < infoStore.catalysts.Count; j++)
            {
                Console.WriteLine($"{j+1} - {infoStore.catalysts[j]}");
            }

            int choice = 1;
            string input = Console.ReadLine() ?? "1";
            if (Int32.TryParse(input, out int i)) { choice = i-1; }
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\nYou have chosen, {infoStore.catalysts[choice]}.");

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
            Console.Clear();
            Console.WriteLine("\n current levels:");
            Console.WriteLine($" temperatrus: {temperatrus * 100 / 255}%");
            Console.WriteLine($" irascribilis: {irascribilis * 100 / 255}%");
            Console.WriteLine($" intelligentia: {intelligentia * 100 / 255}%");
            Console.WriteLine($" chaos: {chaos * 100 / 255}%\n");

            Console.WriteLine($" [{infoStore.catalysts[choice]}] has been inserted into the socket.\n");

            byte x = 0;
            byte y = 0;
            byte z = 0;


            drawGauge(x);
            drawGauge(y);
            drawGauge(z);

            Console.WriteLine($"Enter the next step");
            input = Console.ReadLine() ?? "wait";



            Console.ReadKey();
            return (255, 255, 255, 255);

        }


        private static void drawGauge(byte reading)
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

            Console.WriteLine($"    [{sb.ToString()}]");
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

        public class Creature
        {
            public Species species { get; }
            public Diet diet { get; }
            public Behaviour behaviour { get; }

            public FacialFeatures facialFeatures { get; }

            public BodyParts bodyParts { get; }

            public ConsoleColor colour { get; }

            public Sizes sizes { get; }

            public Health health { get; }

            public Textures textures { get; }

            internal String creatureName { get; set; }

            public Creature(int x, int y, int z)
            {

                species = (Species)getRandomEnum(typeof(Species));
                diet = (Diet)getRandomEnum(typeof(Diet));
                behaviour = (Behaviour)getRandomEnum(typeof(Behaviour));
                bodyParts = (BodyParts)getRandomEnum(typeof(BodyParts));
                colour = (ConsoleColor)getRandomEnum(typeof(ConsoleColor));
                sizes = (Sizes)getRandomEnum(typeof(Sizes));
                health = (Health)getRandomEnum(typeof(Health));
                textures = (Textures)getRandomEnum(typeof(Textures));

                creatureName = "creature";

            }

            private int getRandomEnum(Type type)
            {
                Random rnd = new Random();
                return rnd.Next(Enum.GetNames(type).Length);
            }

            public void nameCreature(string input)
            {
                creatureName = input;
            }



        }

        public class StorageCollection
        {
            public List<Creature> storedCreatures { get; set; }
            public List<Creature> wildCreatures { get; set; }

            public List<string> catalysts  {get; set;}

            public StorageCollection()
            {
                storedCreatures = new List<Creature>();
                wildCreatures = new List<Creature>();
                catalysts = new List<string>();
                string[] initialCatalysts = new string[] { "nothing", "a weathered grey slate pebble", "a sea-worn bleached bone", "a charred Oak bark strip" };
                catalysts.AddRange(initialCatalysts);
            }
        }

        public enum Species { Mammalia, Aves, Reptilia, Amphibia }
        public enum Diet { Herbivore, Omnivore, Carnivore }
        public enum Behaviour { Nocturnal, Diurnal, matutinal, vespertine } //night-active, day-active, morning-active, evening-active

        public enum FacialFeatures { eyes, ears, mouth, nose, teeth }
        public enum BodyParts { Tail, Claws, Beak, Legs, Flippers }
        public enum Textures { Smooth, Rough, Leathery, Bumpy, Soft, Velvety }
        public enum Sizes { Winding, Stubby, Fat, Thin }
        public enum Health { Vicious, Stunted, Healthy, Menacing, Frail }



    }

}