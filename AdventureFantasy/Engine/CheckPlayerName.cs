namespace AdventureFantasy
{
    public class CheckPlayerName
    {
        public bool IsValid { get; }

        public string ErrorMessage { get; }

        public CheckPlayerName() { }

        public CheckPlayerName(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        private CheckPlayerName IsPlayerNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new CheckPlayerName(false, "The name cannot be empty or white spaces");
            }

            string[] prohibitedWords = new string[]
            {
                ".",
                ",",
                ";",
                ":",
            };

            foreach (string prohibitedWord in prohibitedWords)
            {
                if (name.Contains(prohibitedWord))
                {
                    return new CheckPlayerName(false, $"The name cannot include ({prohibitedWord}), enter a valid name");
                }
            }

            return new CheckPlayerName(true, "Name is ok");
        }

        public string GetPlayerName()
        {
            Console.WriteLine("Please choose your name");
            var name = "";
            CheckPlayerName playerNameCheck = null;

            do
            {
                name = Console.ReadLine();

                playerNameCheck = IsPlayerNameValid(name);

                if (!playerNameCheck.IsValid)
                {
                    Console.WriteLine(playerNameCheck.ErrorMessage);
                }
            } while (!playerNameCheck.IsValid);

            return name!;
        }
    }
}
