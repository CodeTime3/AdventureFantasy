using AdventureFantasy;
using AdventureFantasyUnitTest.Mocks;
using Xunit;

namespace AdventureFantasyUnitTest
{
    public class CheckPlayerNameTestSute
    {
        [Fact]
        public void GetPlayerNameTest()
        {
            ConsoleMock console = new ConsoleMock();
            CheckPlayerName checkPlayerName = new CheckPlayerName(console);
            console.ReadLineReturn = "hello";
            var result = checkPlayerName.GetPlayerName();
            
            Assert.Equal("", result);
        }
    }
}
