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

        public DialogEngine(IStoryTeller storyTeller, IConsole console, Hero hero)
        {   
            _storyTeller = storyTeller;
            _console = console;
            this.hero = hero;
        }

        public void StartAdventure()
        {
            _storyTeller.StartStory(hero);
            AdventureTowardTheGoblin adventureTowardTheGoblin = new AdventureTowardTheGoblin(_console);
            adventureTowardTheGoblin.WalkingTowardsTheBoss(hero);
            AdventureTowardTheTroll adventureTowardTheTroll = new AdventureTowardTheTroll(_console);
            adventureTowardTheTroll.WalkingTowardsTheBoss(hero);
            AdventureTowardTheRatking adventureTowardTheRatking = new AdventureTowardTheRatking(_console);
            adventureTowardTheRatking.WalkingTowardsTheBoss(hero);
            AdventureTowardTheDragon adventureTowardTheDragon = new AdventureTowardTheDragon(_console);
            adventureTowardTheDragon.WalkingTowardsTheBoss(hero);
            _storyTeller.EndOfNarration(hero);
        }
    }
}
