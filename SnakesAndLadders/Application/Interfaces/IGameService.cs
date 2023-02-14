using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGameService
    {
        void Initialize(int players);
        int RollDiceAndMoveForCurrentPlayer();
        bool HasWinner();
        Player GetCurrentPlayer();
        Player GetWinner();
    }
}