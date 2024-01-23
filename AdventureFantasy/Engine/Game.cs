using AdventureFantasy.Abstractions;
using AdventureFantasy.Engine;
using AdventureFantasy.Engine.DialogEngine;
using AdventureFantasy.Engine.HeroEngine;
using AdventureFantasy.Interfaces.HeroInterfaces;
using AdventureFantasy.Interfaces.StoryInterfaces;
using AdventureFantasy.Interfaces.StoryInterfaces.Adventure;

namespace AdventureFantasy
{
    public class Game
    {
        private readonly IConsole? _console;
        private readonly IPlayerNameProvider _playerNameProvider;
        private readonly IPlayerRoleProvider _playerRoleProvider;
        private readonly IStoryTeller _storyTeller;
        private readonly IAdventure _adventure;
        private Hero? _player;

        public bool IsGameRunning { get; private set; }

        public Game(IConsole console, IPlayerNameProvider playerNameProvider, IPlayerRoleProvider playerRoleProvider, IStoryTeller storyTeller, IAdventure adventure)
        {
            _console = console;
            _playerNameProvider = playerNameProvider;
            _playerRoleProvider = playerRoleProvider;
            _storyTeller = storyTeller;
            _adventure = adventure;
        }

        public void StartNewGame()
        {
            if (IsGameRunning)
            {
                _console.WriteLine("The game is already running");
                return;
            }

            IsGameRunning = true;
            
            HeroCreator heroCreator = new HeroCreator(_console, _playerNameProvider, _playerRoleProvider, _player);
            _player = heroCreator.CreateHero();

            DialogEngine dialogEngine = new DialogEngine(_storyTeller,_console, _adventure, _player);
            dialogEngine.StartAdventure();
 
            //TODO: pensare ad un modo per salvare i progressi (usare i file)
            //TODO: stop game
        }
    }
}