using Application.Interfaces;
using Application.ViewModel;
using System.Collections.Generic;

namespace Application.Services
{
    public class GameService : IGameService
    {
        public List<Player> Players { get; set; }

        public GameService()
        {
            Players = new List<Player>();
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

        }
    }
}