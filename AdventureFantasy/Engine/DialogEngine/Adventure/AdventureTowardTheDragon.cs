using AdventureFantasy.Abstractions;
using AdventureFantasy.Characters;
using AdventureFantasy.Interfaces.StoryInterfaces.Adventure;

namespace AdventureFantasy.Engine.DialogEngine.Adventure
{
    public class AdventureTowardTheDragon : IAdventure
    {
        private readonly IConsole _console;

        private List<Slime> _slimeList;

        public AdventureTowardTheDragon(IConsole console)
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

            Thief thief = new Thief("MageThief", "The Mage Thief steals through magic. But, there is only one rule, he grabs everything he gets his hands on!");
            Dragon dragon = new Dragon("Dragon", _console);

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

            _console.WriteLine($"Along the way {hero.Name} meets the {thief.Name}, \n" +
                $"he was controlling the {dragon.Name} mind");
            dragon.StartDialog();
            FightAgainstBoss(hero, dragon, thief);
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

        private void FightAgainstBoss(Hero hero, Dragon dragon, Thief thief)
        {
            do
            {
                hero.Attack(dragon);
                dragon.Attack(hero);
            } while ((dragon.Health > 0) || (hero.Health > 0));

            if (hero.Health > 0)
            {
                _console.WriteLine($"{hero.Name} defeated the {dragon.Name} and the {thief.Name}");

                hero.Health += 20;
                hero.AttackPoints += 4;
                hero.DefensePoints += 4;
            }
            else
            {
                _console.WriteLine($"{dragon.Name} defeated {hero.Name}");
            }
        }
    }
}
