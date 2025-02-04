using Application.Interfaces;
using Application.Services;
using FluentAssertions;
using Moq;
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
            var game = new GameService(new DiceService());

            game.Initialize(1);

            var playerPosition = game.Players.First().Position;
            var expectedPosition = 1;

            playerPosition.Should().Be(expectedPosition);
        }

        // US1 UAT2
        [Fact]
        public void MovePlayerToPosition4_WhenIsMoved3Spaces_GivenIsOnPosition1()
        {
            Mock<IDiceService> mockedDiceService = new Mock<IDiceService>();

            var positionsToMove = 3;
            mockedDiceService.Setup(x => x.Roll()).Returns(positionsToMove);
            var game = new GameService(mockedDiceService.Object);

            game.Initialize(1);

            game.RollDiceAndMoveForCurrentPlayer();

            var playerPosition = game.Players.First().Position;
            var expectedPosition = 4;

            playerPosition.Should().Be(expectedPosition);
        }
        
        // US1 UAT3
        [Fact]
        public void MovePlayerToPosition8_WhenIsMoved3Spaces_AndThenIsMoved4Spaces_GivenIsOnPosition1()
        {
            Mock<IDiceService> mockedDiceService = new Mock<IDiceService>();

            var positionsToMove = 3;
            mockedDiceService.Setup(x => x.Roll()).Returns(positionsToMove);
            var game = new GameService(mockedDiceService.Object);

            game.Initialize(1);

            game.RollDiceAndMoveForCurrentPlayer();

            positionsToMove = 4;
            mockedDiceService.Setup(x => x.Roll()).Returns(positionsToMove);

            game.RollDiceAndMoveForCurrentPlayer();

            var playerPosition = game.Players.First().Position;
            var expectedPosition = 8;

            playerPosition.Should().Be(expectedPosition);
        }
        
        // US2 UAT1
        [Fact]
        public void HaveWinner_WhenIsMoved3Spaces_GivenIsOnPosition97()
        {
            Mock<IDiceService> mockedDiceService = new Mock<IDiceService>();

            var positionsToMove = 3;
            mockedDiceService.Setup(x => x.Roll()).Returns(positionsToMove);
            var game = new GameService(mockedDiceService.Object);

            game.Initialize(1);
            game.Players.First().Position = 97;

            game.RollDiceAndMoveForCurrentPlayer();

            var winner = game.HasWinner();

            winner.Should().BeTrue();
        }

        // US2 UAT2
        [Fact]
        public void NotHaveWinner_WhenIsMoved4Spaces_GivenIsOnPosition93()
        {
            Mock<IDiceService> mockedDiceService = new Mock<IDiceService>();

            var positionsToMove = 4;
            mockedDiceService.Setup(x => x.Roll()).Returns(positionsToMove);
            var game = new GameService(mockedDiceService.Object);

            game.Initialize(1);
            game.Players.First().Position = 93;

            game.RollDiceAndMoveForCurrentPlayer();

            var winner = game.HasWinner();

            winner.Should().BeFalse();
        }
        
        // US3 UAT1
        [Fact]
        public void RollBetween1And6_WhenDiceIsRolled_GivenGameHasStarted()
        {
            var game = new GameService(new DiceService());
            
            game.Initialize(1);

            var result = game.RollDiceAndMoveForCurrentPlayer();

            result.Should().BeInRange(1, 6);
        }

        // US3 UAT2
        [Fact]
        public void MovePlayer4Spaces_WhenThePlayerRollsA4()
        {
            Mock<IDiceService> mockedDiceService = new Mock<IDiceService>();
            mockedDiceService.Setup(x => x.Roll()).Returns(4);
            var game = new GameService(mockedDiceService.Object);

            game.Initialize(1);

            game.RollDiceAndMoveForCurrentPlayer();

            var playerPosition = game.Players.First().Position;
            var expectedPosition = 5;

            playerPosition.Should().Be(expectedPosition);
        }
    }
}