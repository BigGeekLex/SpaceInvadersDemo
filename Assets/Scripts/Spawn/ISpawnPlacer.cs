using UnityEngine;

namespace Spawn
{
    public interface ISpawnPlacer
    {
        Vector2 GetPossiblePositionByIndex(int index);
    }
}