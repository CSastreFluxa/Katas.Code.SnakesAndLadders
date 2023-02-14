using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class GameService : IGameService
    {
        public List<Player> Players { get; set; }
        public IDiceService Dice { get; set; }
        public int CurrentTurn { get; set; }

        public GameService(IDiceService dice)
        {
            Players = new List<Player>();
            Dice = dice;
        }

        public void Initialize(int players)
        {
            Players.Clear();

            for (int id = 1; id <= players; id++)
            {
                Players.Add(new Player(id));
            }

            CurrentTurn = 1;
        }

        public int RollDiceAndMoveForCurrentPlayer()
        {
            if (HasWinner())
            {
                return 0;
            }

            var player = Players.Find(p => p.Id == CurrentTurn);

            var positions = Dice.Roll();

            player.Move(positions);

            CurrentTurn = GetNextTurn();

            return positions;
        }

        public bool HasWinner()
        {
            return Players.Any(p => p.Position == 100);
        }

        public Player GetCurrentPlayer()
        {
            return Players.Find(p => p.Id == CurrentTurn);
        }

        public Player GetWinner()
        {
            return Players.FirstOrDefault(p => p.Position == 100);
        }

        private int GetNextTurn()
        {
            var nextTurn = CurrentTurn + 1;

            if (nextTurn > Players.Count)
            {
                nextTurn = 1;
            }

            return nextTurn;
        }
    }
}