using AdventureFantasy.Abstractions;
using AdventureFantasy.Interfaces.StoryInterfaces.BattleInterfaces;

namespace AdventureFantasy
{
    public class Goblin : Character, ICanAttack, ICanDefend
    {
        private readonly IConsole _console;
        public Goblin(string name, IConsole console) : base(name, health: 30, attackPoints: 3, defensePoints: 2)
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