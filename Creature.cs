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



    }

}