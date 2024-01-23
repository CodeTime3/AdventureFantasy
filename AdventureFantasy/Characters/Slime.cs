using AdventureFantasy.Abstractions;
using AdventureFantasy.Interfaces;
using AdventureFantasy.Interfaces.StoryInterfaces;
using AdventureFantasy.Interfaces.StoryInterfaces.BattleInterfaces;
using static System.Net.Mime.MediaTypeNames;

namespace AdventureFantasy
{
    public class Slime : Character, ICanDefend, IInteract
    {   
        private readonly IConsole _console;
        public Slime(string name, IConsole console) : base(name, health: 8, attackPoints: 0, defensePoints: 2)
        {
            _console = console;
        }

        public void Defend(int damage)
        {
            int actualDamage = Math.Max(0, damage - DefensePoints);
            Health -= actualDamage;
            _console.WriteLine($"{Name} suffers {actualDamage} damage. Remaining health: {Health}");

            if (Health <= 0)
            {
                _console.WriteLine($"{Name} was defeated");
            }
        }

        public void StartDialog()
        {
            _console.WriteLine("Slime appeared");
        }
    }
}
