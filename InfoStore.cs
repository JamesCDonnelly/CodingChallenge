namespace CodingChallenge
{
    internal partial class Program
    {
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

        public static void createReagents(InfoStore infoStore)
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
                                                { 1, 1, 1, 0 } };  // (note the 4x4 grid is not related to math calculation, it's just a coincidence.

            Catalyst catalyst = new Catalyst(name, description, dataMap);
            infoStore.catalysts.Add(catalyst);

            name = "a weathered grey slate pebble";
            description = "The stone is smooth and cold to the touch.";
            dataMap = new int[4, 4] {   { 1, -2, -2, 0},
                                        { 0, 1, -2, 1 },
                                        { -1, -2, 1, 0 },
                                        { 1, 1, 1, 1  } };

            catalyst = new Catalyst(name, description, dataMap);
            infoStore.catalysts.Add(catalyst);

            name = "a sea-worn bleached bone";
            description = "It is surprisingly light and heavily worn with a coarse texture.";
            dataMap = new int[4, 4] {   { 1, 0, -2, 0},
                                        { -2, 1, -2, 0},
                                        { -1, 0, 1, 1},
                                        { 1, 1, 1, 1  } };

            catalyst = new Catalyst(name, description, dataMap);
            infoStore.catalysts.Add(catalyst);

            name = "a charred Oak bark strip";
            description = "The charred end is sooty and crumbly.";
            dataMap = new int[4, 4] {   { 1, 0, 0, 1},
                                        { -1, 1, -1, 0},
                                        { 0, 0, 1, 0},
                                        { 1, 1, 1, 1  } };

            catalyst = new Catalyst(name, description, dataMap);
            infoStore.catalysts.Add(catalyst);
        }
    }
}