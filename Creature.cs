﻿namespace CodingChallenge
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
            public Creature(int x, int y, int z, int m)  //values from 0 to 255
            {
                float i = (x / 255f * 10f * m);
                //Console.WriteLine($"{(int)i}");
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

                creatureName = "unnamed";
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
        public enum Diet { carnivorous, omnivorous, herbivorous }
        public enum Behaviour { matutinal, diurnal,vespertine, nocturnal } //morning-active, day-active, evening-active, night-active
        public enum Senses { temperature, sight, smell, vibration, hearing, emotion, gravity, humidity}
        public enum BodyParts { limbs, tail, claws, beak, legs, flippers, arms, antennae, proboscis, hairs, tendrils, shell}
        public enum Textures { slimy, smooth, rough, leathery, bumpy, soft, velvety  }
        public enum Sizes { gelatinous, winding, stubby, fat, thin, spindly, thick, elongated, boney}
        public enum Health { pulsating, vicious, stunted, frail, healthy, menacing }
        public enum Noises { burbling, callous, terrifying, thunderous, hideous, earsplitting, charismatic, friendly, bellowing, ghastly}
        public enum Cries { wheeze, shout, whisper, scream, roar, shriek, whistle, song, cry, laugh, whine, whimper}
    }
}