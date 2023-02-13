namespace Application.Interfaces
{
    public interface IGameService
    {
        void Initialize(int players);
        void Move(int playerId, int positions);
        bool HasWinner();
    }
}