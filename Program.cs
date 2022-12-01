
using System.Reflection.PortableExecutable;

namespace CodingChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Creature mako = new Creature(Species.Reptilia, Diet.Carnivore, Behaviour.Diurnal);

            Console.WriteLine($"the creature most closely resembles the {mako.species} animal class. It is a {mako.diet} and has has a {mako.behaviour} sleeping pattern.");
        }



      


        public enum Species { Mammalia, Aves, Reptilia, Amphibia }
        public enum Diet { Herbivore, Omnivore, Carnivore }
        public enum Behaviour { Nocturnal, Diurnal, matutinal, vespertine } //night-active, day-active, morning-active, evening-active

        public record Creature(Species species, Diet diet, Behaviour behaviour);


    }

}