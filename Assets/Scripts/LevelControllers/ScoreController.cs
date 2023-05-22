using System;
using Spawn;
using UnityEngine;

namespace LevelControllers
{
    public class ScoreController : IScoreController, IDisposable
    {
        private readonly IEnemySpawner _enemySpawner;
        private int _currentScore = 0;
        private int _scoreForKill;
        
        public event Action<int> OnScoreChanged;
        
        public ScoreController(IEnemySpawner enemySpawner, int scoreForKill)
        {
            _enemySpawner = enemySpawner;
            _scoreForKill = scoreForKill;
            
            _enemySpawner.OnEnemyDespawned += OnEnemyDespawned;
        }
        private void OnEnemyDespawned(Vector2 pos)
        {
            _currentScore += _scoreForKill;
            OnScoreChanged?.Invoke(_currentScore);
        }
        public void Dispose()
        {
            _enemySpawner.OnEnemyDespawned -= OnEnemyDespawned;
        }
    }
}