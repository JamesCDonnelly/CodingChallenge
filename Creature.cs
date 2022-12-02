using System.Security.Cryptography;

namespace CodingChallenge
{
    internal partial class Program
    {
        public class Creature
        {
            public Species species { get; }
            public Diet diet { get; }
            public Behaviour behaviour { get; }

            public Senses senses { get; }

            public BodyParts bodyParts { get; }

            public ConsoleColor colour { get; }

            public Sizes sizes { get; }

            public Health health { get; }

            public Textures textures { get; }

            public Noises noises { get; }

            public Cries cries { get; }

            internal String creatureName { get; set; }

            //x=temperatrus, y=irascribilis, z=intelligentia, m=chaos
            public Creature(int x, int y, int z, int m)  //values from 0 to 255 and 0 - 4
            {
                float i = (x / 255f * 10f * m);
                Console.WriteLine($"{(int)i}");
                species = (Species) Math.Clamp((int)(x/255f * 10f * m), 0, Enum.GetNames(typeof(Species)).Length - 1);
                diet = (Diet)Math.Clamp((int)(y/255f * 10f * m), 0, Enum.GetNames(typeof(Diet)).Length - 1);
                behaviour = (Behaviour)(getRandomEnum(typeof(Behaviour)));
                bodyParts = (BodyParts)Math.Clamp((int)(x / 255f * 10f * m), 0, Enum.GetNames(typeof(BodyParts)).Length - 1);
                colour = (ConsoleColor)getRandomEnum(typeof(ConsoleColor));
                sizes = (Sizes)(getRandomEnum(typeof(Sizes)) * m);
                health = (Health)(getRandomEnum(typeof(Health)) * m);
                textures = (Textures)(getRandomEnum(typeof(Textures)) * m);
                senses = (Senses)(getRandomEnum(typeof(Senses)) * m);
                noises = (Noises)(getRandomEnum(typeof(Noises)) * m);
                cries = (Cries)(getRandomEnum(typeof(Cries)) * m);

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

        public enum Species { Abomination, Osteichthyes, Amphibia, Mammalia, Aves, Reptilia}
        public enum Diet { Carnivore, Omnivore, Herbivore }
        public enum Behaviour { matutinal, Diurnal,vespertine, Nocturnal } //morning-active, day-active, evening-active, night-active
        public enum Senses { temperature, vision, smell, vibration, noise, emotion}
        public enum BodyParts { limbs, tail, claws, beak, legs, flippers, arms, antennae, proboscis, hairs, tendrils }
        public enum Textures { slimy, smooth, rough, leathery, bumpy, soft, velvety  }
        public enum Sizes { gelatinous, winding, stubby, fat, thin, spindly }
        public enum Health { pulsating, vicious, stunted, frail, healthy, menacing }
        public enum Noises { burbling, callous, terrifying, thunderous, hideous, earsplitting, charismatic, friendly, bellowing}
        public enum Cries { noise, shout, whisper, scream, roar, shriek, whistle, song, cry}



    }

}