using AdventureFantasy.Abstractions;

namespace AdventureFantasy
{
    internal class Program
    {
        private static readonly ConsoleWrapper _console;
        static void Main(string[] args)
        {
            Game game = new Game(_console);
            game.StartNewGame();
        }
    }
}
