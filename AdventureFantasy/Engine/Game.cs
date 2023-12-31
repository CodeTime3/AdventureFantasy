﻿namespace AdventureFantasy
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

            IsGameRunning = true;

            DisplayWelcomeMessage();

            CheckPlayerName checkPlayerName = new CheckPlayerName();
            var name = checkPlayerName.GetPlayerName();

            ChooseHeroRole chooseHeroRole = new ChooseHeroRole();
            Roles roles = chooseHeroRole.GetPlayerRole();

            Hero hero = new Hero(name, roles);

            // TODO: iniziano i turni

            // TODO: stop game
        }  

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the land of Yorwyn");
        }
    }
}