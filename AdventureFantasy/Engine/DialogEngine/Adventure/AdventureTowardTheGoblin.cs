using AdventureFantasy.Abstractions;
using AdventureFantasy.Interfaces.StoryInterfaces.Adventure;
using System;
namespace AdventureFantasy.Engine.DialogEngine.Adventure
{
    public class AdventureTowardTheGoblin : IAdventure
    {
        private readonly IConsole _console;

        private List<Slime> _slimeList;

        public AdventureTowardTheGoblin(IConsole console)
        {
            _console = console;
        }

        private List<Slime> GetSlimeList()
        {
            _slimeList.Add(new Slime("Slime #1", _console));
            _slimeList.Add(new Slime("Slime #2", _console));
            _slimeList.Add(new Slime("Slime #3", _console));
            return _slimeList;
        }

        public void WalkingTowardsTheBoss(Hero hero)
        {
            _console.WriteLine($"Along the way {hero.Name} meets three slimes.");

            Dragon goblin = new Dragon("Goblin", _console);
            
            _console.WriteLine("Do you wanna fight or run away?");
            _console.WriteLine("Type \"fight\" if you wanna fight against slimes, otherwise type run");
            string choice = string.Empty;

            do
            {
                choice = _console.ReadLine().ToLower();

                if (choice.Equals("fight"))
                {
                    _slimeList = GetSlimeList();
                    FightAgainstSlime(hero);
                    _console.WriteLine($"{hero.Name} defeated slimes");
                }
                else if (choice.Equals("run"))
                {
                    _console.WriteLine($"{hero.Name} run away from slimes");
                }
                else
                {
                    _console.WriteLine("Type \"fight\" or \"run\"");
                }
            } while ((choice.Equals("fight")) || (choice.Equals("run")));

            _console.WriteLine($"Along the way {hero.Name} meets the {goblin.Name}");
            goblin.StartDialog();
            FightAgainstBoss(hero, goblin);
        }

        private void FightAgainstSlime(Hero hero)
        {
            foreach (var slime in _slimeList)
            {
                do
                {
                    hero.Attack(slime);
                } while (slime.Health > 0);

                hero.Health += 10;
                hero.AttackPoints += 2;
                hero.DefensePoints += 2;
            }
        }

        private void FightAgainstBoss(Hero hero, Dragon goblin)
        {
            do
            {
                hero.Attack(goblin);
                goblin.Attack(hero);
            } while ((goblin.Health > 0) || (hero.Health > 0));

            if (hero.Health > 0)
            {
                _console.WriteLine($"{hero.Name} defeated the {goblin.Name}");

                hero.Health += 20;
                hero.AttackPoints += 4;
                hero.DefensePoints += 4;
            }
            else
            {
                _console.WriteLine($"{goblin.Name} defeated {hero.Name}");
            }
        }
    }
}
