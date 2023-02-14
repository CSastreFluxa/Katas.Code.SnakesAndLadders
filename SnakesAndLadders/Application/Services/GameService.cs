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

        public GameService(IDiceService dice)
        {
            Players = new List<Player>();
            Dice = dice;
        }

        public void Initialize(int players)
        {
            for (int id = 1; id <= players; id++)
            {
                Players.Add(new Player(id));
            }
        }

        public int RollDiceAndMove(int playerId)
        {
            var player = Players.Find(p => p.Id == playerId);

            var positions = Dice.Roll();

            player.Move(positions);
            
            return positions;
        }

        public bool HasWinner()
        {
            return Players.Any(p => p.Position == 100);
        }
    }
}