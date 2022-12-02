namespace CodingChallenge
{
    internal partial class Program
    {
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

            public Creature(int x, int y, int z, int m)
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