using AdventureFantasy.Abstractions;
using AdventureFantasy.Interfaces.StoryInterfaces;

namespace AdventureFantasy.Characters
{
    public class Thief
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Thief(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Name}, {Description}";
        }
    }
}
