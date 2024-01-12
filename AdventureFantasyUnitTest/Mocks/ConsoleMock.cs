using AdventureFantasy.Abstractions;

namespace AdventureFantasyUnitTest.Mocks
{
    internal class ConsoleMock : IConsole
    {
        public string? LastCall { get; set; }
        public string? ReadLineReturn { get; set; }

        public string? ReadLine()
        {
            return ReadLineReturn;
        }

        public void WriteLine(string? message)
        {
            LastCall = message;
        }
    }
}
