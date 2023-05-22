using System;

namespace LevelControllers
{
    public interface IScoreController
    {
        event Action<int> OnScoreChanged;
    }
}