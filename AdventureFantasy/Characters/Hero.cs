using AdventureFantasy.Abstractions;
using AdventureFantasy.Interfaces.StoryInterfaces.BattleInterfaces;

namespace AdventureFantasy
{
    public class Hero : Character, ICanDefend, ICanAttack
    {   
        private readonly IConsole _console;
        public Roles Role { get; set; } = Roles.Warrior;

        public Hero(string name, Roles role, IConsole console) : base(name, health: 100, attackPoints: 10, defensePoints: 10)
        {   
            Role = role;
            _console = console;
        }

        public void Defend(int damage)
        {
            int actualDamage = Math.Max(0, damage - DefensePoints);
            Health -= actualDamage;
            _console.WriteLine($"{Name} suffers {actualDamage} damage. Remaining health: {Health}");

            if(Health <= 0) 
            {
                _console.WriteLine($"{Name} was defeated");
            }
        }

        public void Attack(ICanDefend opponent)
        {
            _console.WriteLine($"{Name} attacks {opponent.GetType().Name}!");
            opponent.Defend(AttackPoints);
        }

        public override string ToString()
        {
            return $"Name: {Name}" + 
                $" | Role: {Role}" +
                $" | Health: {Health}" +
                $" | Attack points: {AttackPoints}"+
                $" | Defense points: {DefensePoints}";
        }
    }
}
