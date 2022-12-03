using static CodingChallenge.Program;

namespace CodingChallenge
{
	partial class Menagerie
	{
		internal static void TheMenagerie(InfoStore infoStore)
		{
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            if (infoStore.storedCreatures.Count == 0) { Console.WriteLine($"\n\n    Currently there are no creatures stored at the menagerie."); Console.ReadKey(); return; }
            else
            {
                if (infoStore.storedCreatures.Count == 1) { Console.WriteLine($"\n\n    Currently there is {infoStore.storedCreatures.Count} creature stored at the menagerie."); }
                else { Console.WriteLine($"\n\n     Currently there are {infoStore.storedCreatures.Count} creatures stored at the menagerie."); }
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

                if (debug) { Console.WriteLine($"DEBUG {index}"); }
                if (debug) { Console.WriteLine($"DEBUG storecreatures count {infoStore.storedCreatures.Count}"); }

                Creature creature = infoStore.storedCreatures[index];
                Console.Write($"[PEN: {index + 1}]");
                Console.Write($"\nThis creature is {creature.creatureName}.\n\n This creature most closely resembles species from the {creature.species} animal class.\n" +
                                  $" It is {creature.diet} and has a {creature.behaviour} sleeping pattern.\n" +
                                  $" Its {creature.sizes} {creature.colour.ToString().ToLower()} {creature.bodyParts} appears {creature.textures} and {creature.health}.\n\n" +
                                  $" It can detect other presences using its strong sense of {creature.senses}.");

                Random rnd = new Random();
                if (rnd.Next(1, 5) == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" It can detect you now.\n\n   ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($" It calls out with a {creature.noises} {creature.cries}.\n\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else { Console.WriteLine($"\n The creature cannot detect you right now, you should come back later.\n\n"); }

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
                        if (index < 0) { index = infoStore.storedCreatures.Count - 1; }
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
        internal static void nameCreature(Creature creature)
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
    }
}
