using AdventureFantasy.Abstractions;
using AdventureFantasy.Interfaces.HeroInterfaces;

namespace AdventureFantasy.Engine.HeroEngine
{
    public class HeroCreator
    {
        private readonly IConsole _console;
        private readonly IPlayerNameProvider _playerNameProvider;
        private readonly IPlayerRoleProvider _playerRoleProvider;
        private Hero? _hero;

        public HeroCreator(IConsole console, IPlayerNameProvider playerNameProvider, IPlayerRoleProvider playerRoleProvider, Hero? hero)
        {
            _console = console;
            _playerNameProvider = playerNameProvider;
            _playerRoleProvider = playerRoleProvider;
            _hero = hero;
        }

        public Hero CreateHero()
        {
            var name = _playerNameProvider.GetPlayerName();
            var role = _playerRoleProvider.GetPlayerRole();

            _hero = new Hero(name, role, _console);

            _console.WriteLine(_hero.ToString());

            return _hero;
        }
    }
}
