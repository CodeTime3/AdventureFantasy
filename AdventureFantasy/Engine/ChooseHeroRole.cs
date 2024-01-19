using AdventureFantasy.Abstractions;
using AdventureFantasy.Engine;
using System.Data;

namespace AdventureFantasy
{
    public class ChooseHeroRole
    {
        private readonly IConsole _console;

        private string[] HeroRoles =
        {
                "warrior",
                "cleric",
                "rouge",
                "mage"
        };

        public ChooseHeroRole() { }

        public ChooseHeroRole(IConsole console)
        {
            _console = console;
        }

        private Result IsRolePlayerValid(string RoleName)
        {
            if (string.IsNullOrWhiteSpace(RoleName))
            {
                return new Result(false, "Enter a valid role");
            }

            foreach (var HeroRole in HeroRoles)
            {
                if (RoleName.Equals(HeroRole))
                {
                    return new Result(true, "The role is ok");
                }
            }

            return new Result(false, $"The role ({RoleName}) doesn't exist, enter a valid role");
        }

        public Roles GetPlayerRole()
        {
            _console.WriteLine("Please choose a role");
            _console.WriteLine("Warrior, Cleric, Rouge, Mage. Enter the name of the role");
            var RoleName = "";
            Result ChooseHeroRole = null;

            do
            {
                RoleName = _console.ReadLine().ToLower();

                ChooseHeroRole = IsRolePlayerValid(RoleName);

                if (!ChooseHeroRole.IsValid)
                {
                    _console.WriteLine(ChooseHeroRole.ErrorMessage);
                }
            } while (!ChooseHeroRole.IsValid);

            return Enum.Parse<Roles>(RoleName, true);
        }
    }
}
