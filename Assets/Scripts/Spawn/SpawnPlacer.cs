using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Spawn
{
    public class SpawnPlacer : ISpawnPlacer 
    {
        private IScreenBound _screenBound;
        private Vector2[] _spawnPositions;

        private int _yOffset;
        public SpawnPlacer(IScreenBound screenBound, int yOffset = 4)
        {
            _screenBound = screenBound;
            _yOffset = yOffset;
            _spawnPositions = CalculatePossiblePositions();
        }
        public Vector2 GetPossiblePositionByIndex(int index)
        {
            if (index >= _spawnPositions.Length) return Vector2.zero; 
                
            return _spawnPositions[index];
        }
        private Vector2[] CalculatePossiblePositions()
        {
            Vector2Int bound = _screenBound.GetBound();
            
            List<Vector2> positions = new List<Vector2>();
            
            for (int i = bound.y; i <= Mathf.Abs(bound.x); i++)
            {
                for (int j = bound.x; j <= Mathf.Abs(bound.x); j++)
                {
                    positions.Add(new Vector2(j, i + _yOffset));
                }
            }
            return positions.ToArray();
        }
    }
}