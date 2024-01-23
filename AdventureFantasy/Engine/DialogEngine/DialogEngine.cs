using AdventureFantasy.Abstractions;
using AdventureFantasy.Engine.DialogEngine.Adventure;
using AdventureFantasy.Interfaces.StoryInterfaces;
using AdventureFantasy.Interfaces.StoryInterfaces.Adventure;

namespace AdventureFantasy.Engine.DialogEngine
{
    public class DialogEngine
    {
        private readonly IStoryTeller _storyTeller;
        private readonly IConsole _console;
        private Hero? hero;
        private IAdventure _adventure;

        public DialogEngine(IStoryTeller storyTeller, IConsole console, IAdventure adventure, Hero hero)
        {   
            _storyTeller = storyTeller;
            _console = console;
            _adventure = adventure;
            this.hero = hero;
        }

        public void StartAdventure()
        {
            _storyTeller.StartStory(hero);
            _adventure = new AdventureTowardTheGoblin(_console);
            _adventure = new AdventureTowardTheTroll(_console);
            _adventure = new AdventureTowardTheRatking(_console);
            _adventure = new AdventureTowardTheDragon(_console);
            _storyTeller.EndOfNarration(hero);
        }
    }
}
