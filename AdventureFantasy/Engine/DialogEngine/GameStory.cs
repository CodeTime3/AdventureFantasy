using AdventureFantasy.Abstractions;
using AdventureFantasy.Characters;
using AdventureFantasy.Interfaces.StoryInterfaces;

namespace AdventureFantasy.Engine.DialogEngine
{
    public class GameStory : IStoryTeller
    {
        private readonly IConsole _console;
        private Amulet _amulet = new Amulet("Heart of Aetheria", "An ancient magical amulet with the power to control the elements");
        Thief thief = new Thief("MageThief", "The Mage Thief steals through magic. But, there is only one rule, he grabs everything he gets his hands on!");
        public GameStory(IConsole console)
        {
            _console = console;
        }

        public void StartStory(Hero hero)
        {
            DisplayWelcomeMessage();
            BegginningOfNarration(hero);
        }

        private void BegginningOfNarration(Hero hero)
        {
            _console.WriteLine("In the wild territories of Yorwyn, an ancient magical amulet, known as the Heart \n" +
                "of Aetheria, has been stolen from its sacred crypt.It is said that this amulet \n" +
                "holds the power to control the elements themselves and can bring prosperity or \n" +
                "destruction to anyone who wields it. \n");

            _console.WriteLine("The Council of Arcane has sent out a desperate appeal to all adventurers and \n" +
                "treasure seekers in the region. They offer a generous reward for the recovery \n" +
                "of the amulet and the capture of the thieves responsible for the theft. \n");

            _console.WriteLine($"Many came! After {hero.Name}, the seeker, was recruited and assigned the" + 
                $"task of retrieving\nthe {_amulet.Name} amulet! He granted the request, and began to walk the long path...");
        }

        //Dopo tutti gli scontri e le avversità heroname è riuscito a recuperare the amuletname, 
        //subito dopo aver fatto ritorno nella sua terra è stato acclamato da tutto il popolo
        public void EndOfNarration(Hero hero)
        {
            _console.WriteLine($"After all these fights and hardships thereof, {hero.Name} managed to recover\n " +
                $"the {_amulet.Name} amulet. As soon as he returned to his land, he was acclaimed by all the\n " +
                $"people as a victorious hero, wishing him a splendid life of happiness and well-being!");
        }

        private void DisplayWelcomeMessage()
        {
            _console.WriteLine("Welcome to the land of Yorwyn \n");
            _console.WriteLine("----------------------------------------------------------------------------------- \n");
        }
    }
}
