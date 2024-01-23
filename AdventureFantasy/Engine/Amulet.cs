namespace AdventureFantasy.Engine
{
    public class Amulet
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Amulet(string name, string description)
        {
            Name = name; // Heart of Aetheria
            Description = description; //An ancient magical amulet with the power to control the elements
        }

        public override string ToString()
        {
            return $"{Name}, {Description}";
        }
    }
}
