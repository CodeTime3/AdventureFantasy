using AdventureFantasy.Abstractions;
using AdventureFantasy.Interfaces.StoryInterfaces;
using AdventureFantasy.Interfaces.StoryInterfaces.BattleInterfaces;

namespace AdventureFantasy
{
    public class Dragon : Character, ICanAttack, ICanDefend, IInteract
    {
        private readonly IConsole _console;
        public Dragon(string name, IConsole console) : base(name, health: 300, attackPoints: 20, defensePoints: 15)
        {
            _console = console;
        }

        public void Attack(ICanDefend opponent)
        {
            _console.WriteLine($"{Name} attacks {opponent.GetType().Name}!");
            opponent.Defend(AttackPoints);
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
            _console.WriteLine($"The {Name} appeared");
        }
    }
}
