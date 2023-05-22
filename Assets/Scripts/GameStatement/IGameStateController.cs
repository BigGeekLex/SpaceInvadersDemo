using System;

namespace GameStatement
{
    public interface IGameStateController
    {
        event Action<GameState> OnGameStateChanged;
        
        void SetGameState(GameState state);
    }
}