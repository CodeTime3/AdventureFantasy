using AdventureFantasy.Abstractions;
using AdventureFantasy.Engine;
using AdventureFantasy.Interfaces.HeroInterfaces;
using System.Data;

namespace AdventureFantasy.Engine.HeroEngine
{
    public class ChooseHeroRole : IPlayerRoleProvider
    {
        private readonly IConsole _console;

        private string[] HeroRoles =
        {
                "warrior",
                "cleric",
                "rouge",
                "mage"
        };

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
            _console?.WriteLine("What's your favorite role?");
            _console?.WriteLine("Warrior, Cleric, Rouge, Mage. Enter the name of the role");
            string? RoleName;
            Result? ChooseHeroRole;

            do
            {
                RoleName = _console?.ReadLine().ToLower();

                ChooseHeroRole = IsRolePlayerValid(RoleName);

                if (!ChooseHeroRole.IsValid)
                {
                    _console?.WriteLine(ChooseHeroRole.ErrorMessage);
                }
            } while (!ChooseHeroRole.IsValid);

            return Enum.Parse<Roles>(RoleName, true);
        }
    }
}
