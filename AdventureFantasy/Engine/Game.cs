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
        private readonly IConsole _console;
        private readonly IPlayerNameProvider _playerNameProvider;
        private readonly IPlayerRoleProvider _playerRoleProvider;
        private readonly IStoryTeller _storyTeller;

        public bool IsGameRunning { get; private set; }

        public Game(IConsole console, IPlayerNameProvider playerNameProvider, IPlayerRoleProvider playerRoleProvider, IStoryTeller storyTeller)
        {
            _console = console;
            _playerNameProvider = playerNameProvider;
            _playerRoleProvider = playerRoleProvider;
            _storyTeller = storyTeller;
        }

        public void StartNewGame()
        {
            IsGameRunning = true;
            
            HeroCreator heroCreator = new HeroCreator(_console, _playerNameProvider, _playerRoleProvider);
            var hero = heroCreator.CreateHero();

            DialogEngine dialogEngine = new DialogEngine(_storyTeller,_console, hero);
            dialogEngine.StartAdventure();
        }
    }
}