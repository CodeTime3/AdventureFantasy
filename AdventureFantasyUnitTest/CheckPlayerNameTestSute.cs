using AdventureFantasy.Engine.HeroEngine;
using AdventureFantasyUnitTest.Mocks;
using Xunit;

namespace AdventureFantasyUnitTest
{
    public class CheckPlayerNameTestSute
    {
        //TODO: fare gli unit test 
        [Fact]
        public void GetPlayerNameTest()
        {
            ConsoleMock console = new ConsoleMock();
            CheckPlayerName checkPlayerName = new CheckPlayerName(console);
            console.ReadLineReturn = "hello";
            var result = checkPlayerName.GetPlayerName();
            
            Assert.Equal("hello", result);
        }
    }
}
