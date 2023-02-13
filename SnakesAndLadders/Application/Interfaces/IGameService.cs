﻿namespace Application.Interfaces
{
    public interface IGameService
    {
        void Initialize(int players);
        void Move(int playerId, int positions);
        void RandomMove(int playerId);
        bool HasWinner();
    }
}