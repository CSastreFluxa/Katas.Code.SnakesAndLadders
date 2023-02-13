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

        // US1 UAT2
        [Fact]
        public void MovePlayerToPosition4_WhenIsMoved3Spaces_GivenIsOnPosition1()
        {
            var game = new GameService();

            game.Initialize(1);
            game.Players.First().Position = 1;

            var playerId = 1;
            var positionsToMove = 3;
            game.Move(playerId, positionsToMove);

            var playerPosition = game.Players.First().Position;
            var expectedPosition = 4;

            playerPosition.Should().Be(expectedPosition);
        }

        // US1 UAT3
        [Fact]
        public void MovePlayerToPosition8_WhenIsMoved3Spaces_AndThenIsMoved4Spaces_GivenIsOnPosition1()
        {
            var game = new GameService();

            game.Initialize(1);
            game.Players.First().Position = 1;

            var playerId = 1;
            var positionsToMove = 3;
            game.Move(playerId, positionsToMove);
            positionsToMove = 4;
            game.Move(playerId, positionsToMove);

            var playerPosition = game.Players.First().Position;
            var expectedPosition = 8;

            playerPosition.Should().Be(expectedPosition);
        }
    }
}
