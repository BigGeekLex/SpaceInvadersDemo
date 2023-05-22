using System;
using GameplaySettings;

namespace LevelControllers
{
    public interface IRoundController
    {
        event Action<int, RoundData> OnRoundStarted;
        event Action OnRoundFinished;
    }
}