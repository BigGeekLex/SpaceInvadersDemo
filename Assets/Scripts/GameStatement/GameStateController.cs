using System;

namespace GameStatement
{
    public class GameStateController : IGameStateController
    {
        public event Action<GameState> OnGameStateChanged;
        
        public void SetGameState(GameState state)
        {
            OnGameStateChanged?.Invoke(state);    
        }
    }
}