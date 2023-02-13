using Application.Interfaces;
using Application.ViewModel;
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

        public void Move(int playerId, int positions)
        {
            var player = Players.Find(p => p.Id == playerId);
            player.Move(positions);
        }

        public void RandomMove(int playerId)
        {
            var player = Players.Find(p => p.Id == playerId);

            var positions = Dice.Roll();

            player.Move(positions);
        }

        public bool HasWinner()
        {
            return Players.Any(p => p.Position == 100);
        }
    }
}