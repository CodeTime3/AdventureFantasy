using AdventureFantasy.Abstractions;
using AdventureFantasy.Interfaces.StoryInterfaces.Adventure;

namespace AdventureFantasy.Engine.DialogEngine.Adventure
{
    public class AdventureTowardTheTroll : IAdventure
    {
        private readonly IConsole _console;

        private List<Slime> _slimeList;

        public AdventureTowardTheTroll(IConsole console)
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

            Dragon troll = new Dragon("Troll", _console);

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

            _console.WriteLine($"Along the way {hero.Name} meets the {troll.Name}");
            troll.StartDialog();
            FightAgainstBoss(hero, troll);
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

        private void FightAgainstBoss(Hero hero, Dragon troll)
        {
            do
            {
                hero.Attack(troll);
                troll.Attack(hero);
            } while ((troll.Health > 0) || (hero.Health > 0));

            if (hero.Health > 0)
            {
                _console.WriteLine($"{hero.Name} defeated the {troll.Name}");

                hero.Health += 20;
                hero.AttackPoints += 4;
                hero.DefensePoints += 4;
            }
            else
            {
                _console.WriteLine($"{troll.Name} defeated {hero.Name}");
            }
        }
    }
}
