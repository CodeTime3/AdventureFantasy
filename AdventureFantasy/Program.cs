using AdventureFantasy.Abstractions;
using AdventureFantasy.Engine.DialogEngine;
using AdventureFantasy.Engine.HeroEngine;
using AdventureFantasy.Interfaces.HeroInterfaces;
using AdventureFantasy.Interfaces.StoryInterfaces;
using AdventureFantasy.Interfaces.StoryInterfaces.Adventure;

namespace AdventureFantasy
{
    internal class Program
    {
        static void Main(string[] args)
        {   

            //TODO: sistemare le dipendenze 

            //IConsole console = new ConsoleWrapper();
            //IPlayerNameProvider playerNameProvider = new CheckPlayerName(console);
            //IPlayerRoleProvider playerRoleProvider = new ChooseHeroRole(console);
            //IStoryTeller storyTeller = new GameStory(console);
            //IAdventure adventure = new Dragon("Dragon", console);
            //Game game = new Game(console, playerNameProvider, playerRoleProvider, storyTeller, adventure);
            //game.StartNewGame();
        }
    }
}
