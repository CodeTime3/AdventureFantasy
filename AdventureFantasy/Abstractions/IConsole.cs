namespace AdventureFantasy.Abstractions
{
    public interface IConsole
    {
        void WriteLine(string? message);

        string? ReadLine();
    }

    public class ConsoleWrapper : IConsole
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string? message)
        {
            Console.WriteLine(message);
        }
    }
}
