using AdventureFantasy.Abstractions;
using AdventureFantasy.Interfaces.HeroInterfaces;

namespace AdventureFantasy.Engine.HeroEngine
{
    public class HeroCreator
    {
        private readonly IConsole _console;
        private readonly IPlayerNameProvider _playerNameProvider;
        private readonly IPlayerRoleProvider _playerRoleProvider;

        public HeroCreator(IConsole console, IPlayerNameProvider playerNameProvider, IPlayerRoleProvider playerRoleProvider)
        {
            _console = console;
            _playerNameProvider = playerNameProvider;
            _playerRoleProvider = playerRoleProvider;
        }
        
        public Hero CreateHero()
        {
            var name = _playerNameProvider.GetPlayerName();
            var role = _playerRoleProvider.GetPlayerRole();

            var hero = new Hero(name, role, _console);

            _console.WriteLine(hero.ToString());

            return hero;
        }
    }
}
