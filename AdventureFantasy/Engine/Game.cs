namespace AdventureFantasy
{
    public class Game
    {
        private List<Character> _enemies;

        private Hero? _player;

        public bool IsGameRunning { get; private set; }

        public Game()
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
        }

        public void StartNewGame()
        {
            if (IsGameRunning)
            {
                Console.WriteLine("The game is already running");
                return;
            }

            this.IsGameRunning = true;

            // TODO: messaggio di benvenuto al giocatore
            this.DisplayWelcomeMessage();

            // TODO: chiedere al giocatore di scegliere un nome

            // TODO: chiedere al giocatore di scegliere un ruolo

            // TODO: costruire il nostro hero

            // TODO: iniziano i turni

            // TODO: stop game
        }  

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine("Messaggio di benvuto....");
        }
    }
}