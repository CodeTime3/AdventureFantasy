using AdventureFantasy.Engine;
using AdventureFantasy.Engine.HeroEngine;
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
            
            Assert.Equal("hello", result);
        }

        [Fact]
        public void GetPlayerNameTestTrim()
        {
            ConsoleMock console = new ConsoleMock();
            CheckPlayerName checkPlayerName = new CheckPlayerName(console);
            console.ReadLineReturn = "-hello";
            var result = checkPlayerName.GetPlayerName();

            Assert.Equal("hello", result);
        }

        [Theory]
        [InlineData(null, "The name cannot be empty or with white spaces")]
        [InlineData("", "The name cannot be empty or with white spaces")]
        [InlineData(" ", "The name cannot be empty or with white spaces")]
        [InlineData("John.Doe", "The name cannot include (.), enter a valid name")]
        [InlineData("Jane,Smith", "The name cannot include (,), enter a valid name")]
        [InlineData("Bob;Johnson", "The name cannot include (;), enter a valid name")]
        [InlineData("Alice:Wonderland", "The name cannot include (:), enter a valid name")]
        public void GetPlayerName_RejectsInvalidInput(string? input, string expectedErrorMessage)
        {
            ConsoleMock console = new ConsoleMock();
            CheckPlayerName checkPlayerName = new CheckPlayerName(console);
            console.ReadLineReturn = input;

            var exception = Assert.Throws<ArgumentException>(() => checkPlayerName.GetPlayerName());
            Assert.Equal(expectedErrorMessage, exception.Message);
        }
    }
}
