using AdventureFantasy.Abstractions;

namespace AdventureFantasy
{
    public class Game
    {
        private List<Character> _enemies;
        private IConsole _console;

        private Hero? _player;

        public bool IsGameRunning { get; private set; }

        public Game(IConsole console)
        {
            this._enemies = new List<Character>()
            {
                new Dragon("Red Dragon"),
                new Dragon("Golden Dragon"),
                new Goblin("Goblin #1"),
                new Goblin("Goblin #2"),
                new Troll("Paolo"),
                new Slime("Slime #1"),
                new Slime("Slime #2")
            };

            _console = console;
        }

        public void StartNewGame()
        {
            if (IsGameRunning)
            {
                _console.WriteLine("The game is already running");
                return;
            }

            IsGameRunning = true;

            DisplayWelcomeMessage();

            CheckPlayerName checkPlayerName = new CheckPlayerName(_console);
            var name = checkPlayerName.GetPlayerName();

            ChooseHeroRole chooseHeroRole = new ChooseHeroRole();
            Roles roles = chooseHeroRole.GetPlayerRole();

            Hero hero = new Hero(name, roles);

            _console.WriteLine(hero.ToString());

            // TODO: iniziano i turni

            // TODO: stop game
        }  

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the land of Yorwyn");
        }
    }
}