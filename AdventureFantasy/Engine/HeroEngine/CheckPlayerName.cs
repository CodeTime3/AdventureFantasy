using AdventureFantasy.Abstractions;
using AdventureFantasy.Engine;
using AdventureFantasy.Interfaces.HeroInterfaces;

namespace AdventureFantasy.Engine.HeroEngine
{
    public class CheckPlayerName : IPlayerNameProvider
    {
        private readonly IConsole _console;

        public CheckPlayerName(IConsole console)
        {
            _console = console;
        }

        private Result IsPlayerNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new Result(false, "The name cannot be empty or with white spaces");
            }

            char[] forbiddenWords =
            {
                '.',
                ',',
                ';',
                ':'
            };

            foreach (char forbiddenWord in forbiddenWords)
            {
                if (name.Contains(forbiddenWord))
                {
                    return new Result(false, $"The name cannot include ({forbiddenWord}), enter a valid name");
                }
            }

            return new Result(true, "Name is valid");
        }

        public string GetPlayerName()
        {
            _console?.WriteLine("What's your name?");
            Result playerNameCheck;
            string? name;

            do
            {
                name = _console?.ReadLine().Trim('_', '-', ' ');

                playerNameCheck = IsPlayerNameValid(name);

                if (!playerNameCheck.IsValid)
                {
                    _console?.WriteLine(playerNameCheck.ErrorMessage);
                }
            } while (!playerNameCheck.IsValid);

            return name!;
        }
    }
}
