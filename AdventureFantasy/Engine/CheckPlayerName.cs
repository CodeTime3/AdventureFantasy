using AdventureFantasy.Abstractions;
using AdventureFantasy.Engine;

namespace AdventureFantasy
{
    public class CheckPlayerName
    {

        private readonly IConsole _console;
        
        private Result Result;

        public CheckPlayerName() { }

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
            _console.WriteLine("Choose your name, please");
            Result playerNameCheck;
            string? name;

            do
            {
                name = _console.ReadLine();
                //isVal = !string.IsNullOrWhiteSpace(name) && name?.Contains(new char[] { ',' });

                playerNameCheck = IsPlayerNameValid(name);

                if (!playerNameCheck.IsValid)
                {
                    _console.WriteLine(playerNameCheck.ErrorMessage);
                }
            } while (!playerNameCheck.IsValid);

            return name!;
        }
    }
}
