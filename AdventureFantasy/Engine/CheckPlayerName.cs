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
                return new CheckPlayerName(false, "The name cannot be empty or with white spaces");
            }

            string[] forbiddenWords = new string[]
            {
                ".",
                ",",
                ";",
                ":",
            };

            foreach (string forbiddenWord in forbiddenWords)
            {
                if (name.Contains(forbiddenWord))
                {
                    return new CheckPlayerName(false, $"The name cannot include ({forbiddenWord}), enter a valid name");
                }
            }

            return new CheckPlayerName(true, "Name is valid");
        }

        public string GetPlayerName()
        {
            Console.WriteLine("Choose your name, please");
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
