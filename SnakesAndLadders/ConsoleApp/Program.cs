using Application;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = GetServiceProvider();

            var game = serviceProvider.GetService<IGameService>();

            Console.WriteLine("Snakes and ladders game");
            Console.WriteLine();

            var isNumber = false;
            var playersAmount = 1;

            while (!isNumber)
            {
                Console.Write("How many players will play the game? ");
                var playersAmountString = Console.ReadLine();
                isNumber = int.TryParse(playersAmountString, out playersAmount);
            }

            game.Initialize(playersAmount);

            while (!game.HasWinner())
            {
                var currentPlayer = game.GetCurrentPlayer();

                Console.WriteLine();
                Console.Write("It is player " + currentPlayer.Id + "'s turn and he is in square " + currentPlayer.Position +". Press any key to roll the dice.");
                Console.ReadKey();
                Console.WriteLine();

                var positionsMoved = game.RollDiceAndMoveForCurrentPlayer();

                Console.WriteLine("Player " + currentPlayer.Id + " has moved " + positionsMoved + " position and he is on square " + currentPlayer.Position + ".");
            }

            var winnerPlayer = game.GetWinner();
            Console.Write("Player " + winnerPlayer.Id + " has won the game. Press any key to exit.");
            Console.ReadKey();
        }

        private static ServiceProvider GetServiceProvider()
        {
            var serviceProvider = new ServiceCollection();

            serviceProvider.AddPersistence();

            return serviceProvider.BuildServiceProvider();
        }
    }
}