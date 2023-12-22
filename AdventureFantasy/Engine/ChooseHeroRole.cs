namespace AdventureFantasy
{
    public class ChooseHeroRole
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; }

        public ChooseHeroRole() { } 

        public ChooseHeroRole(bool isValid, string errorMessage)
        {
            IsValid = isValid; 
            ErrorMessage = errorMessage;
        }

        private CheckPlayerName IsRolePlayerValid(string NameRole)
        {
            if (string.IsNullOrWhiteSpace(NameRole))
            {
                return new CheckPlayerName(false, "Enter a valid role");
            }

            string[] HeroRoles = 
            {
                "warrior",
                "cleric",
                "rouge",
                "mage"
            };

            foreach (var HeroRole in HeroRoles)
            {
                if(NameRole.Equals(HeroRole))
                {
                    return new CheckPlayerName(true, "The role is ok");
                }
            }

            return new CheckPlayerName(false, $"The role ({NameRole}) doesn't exist, enter a valid role");
        }

        public Roles GetPlayerRole()
        {
            Console.WriteLine("Please choose a role");
            Console.WriteLine("Warrior, Cleric, Rouge, Mage. Enter the name of the role");
            var NameRole = "";
            CheckPlayerName playerNameCheck = null;

            do
            {
                NameRole = Console.ReadLine().ToLower();

                playerNameCheck = IsRolePlayerValid(NameRole);

                if (!playerNameCheck.IsValid)
                {
                    Console.WriteLine(playerNameCheck.ErrorMessage);
                }
            } while (!playerNameCheck.IsValid);

            if (NameRole.Equals("cleric")) 
            {
                return Roles.Cleric;
            }else if (NameRole.Equals("rouge"))
            {
                return Roles.Rogue;
            }else if (NameRole.Equals("mage"))
            {
                return Roles.Mage;
            }

            return Roles.Warrior;
        }
    }
}
