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

        private CheckPlayerName IsRolePlayerValid(string RoleName)
        {
            if (string.IsNullOrWhiteSpace(RoleName))
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
                if(RoleName.Equals(HeroRole))
                {
                    return new CheckPlayerName(true, "The role is ok");
                }
            }

            return new CheckPlayerName(false, $"The role ({RoleName}) doesn't exist, enter a valid role");
        }

        public Roles GetPlayerRole()
        {
            Console.WriteLine("Please choose a role");
            Console.WriteLine("Warrior, Cleric, Rouge, Mage. Enter the name of the role");
            var RoleName = "";
            CheckPlayerName CheckPlayerName = null;

            do
            {
                RoleName = Console.ReadLine().ToLower();

                CheckPlayerName = IsRolePlayerValid(RoleName);

                if (!CheckPlayerName.IsValid)
                {
                    Console.WriteLine(CheckPlayerName.ErrorMessage);
                }
            } while (!CheckPlayerName.IsValid);

            if (RoleName.Equals("cleric")) 
            {
                return Roles.Cleric;
            }else if (RoleName.Equals("rouge"))
            {
                return Roles.Rogue;
            }else if (RoleName.Equals("mage"))
            {
                return Roles.Mage;
            }

            return Roles.Warrior;
        }
    }
}
