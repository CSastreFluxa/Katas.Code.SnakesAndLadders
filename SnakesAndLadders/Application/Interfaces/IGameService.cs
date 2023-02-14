namespace Application.Interfaces
{
    public interface IGameService
    {
        void Initialize(int players);
        int RollDiceAndMove(int playerId);
        bool HasWinner();
    }
}