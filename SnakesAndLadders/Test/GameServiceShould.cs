using Application.Services;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace Test
{
    public class GameServiceShould
    {
        // US1 UAT1
        [Fact]
        public void InitializePlayer_WhenGameIsStarted()
        {
            var game = new GameService();

            game.Initialize(1);

            var playerPosition = game.Players.First().Position;
            var expectedPosition = 0;

            playerPosition.Should().Be(expectedPosition);
        }
    }
}
