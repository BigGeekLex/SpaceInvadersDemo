using System;
using System.Threading.Tasks;
using GameplaySettings;
using GameStatement;
using Spawn;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelControllers
{
    public class RoundController : IDisposable, IRoundController
    {
        private IEnemySpawner _enemySpawner;
        private RoundsData _data;
        private IGameStateController _gameStateController;
        
        private const int _millisecondsInSecond = 1000;
        private int _currentRoundEnemies = 0;
        private int _currentRound = 0;
        
        public event Action<int, RoundData> OnRoundStarted;
        
        public event Action OnRoundFinished;
        
        public RoundController(IEnemySpawner enemySpawner, RoundsData data, IGameStateController gameStateController)
        {
            _enemySpawner = enemySpawner;
            _data = data;
            _gameStateController = gameStateController;
            
            _enemySpawner.OnEnemyDespawned += OnEnemyDespawned;
            _gameStateController.OnGameStateChanged += OnGameStarted;
        }
       
        public void Dispose()
        {
            _enemySpawner.OnEnemyDespawned -= OnEnemyDespawned;
        }
        private void OnEnemyDespawned(Vector2 pos)
        {
            _currentRoundEnemies--;

            IsRoundFinished();
        }
        
        private void OnGameStarted(GameState gameState)
        {
            if (gameState != GameState.Started) return;
            
            RoundPrepare();
        }
        private void StartRound(RoundData roundData)
        {
            _currentRound++;
            OnRoundStarted?.Invoke(_currentRound, roundData);
        }
        
        private async void RoundPrepare()
        {
            RoundData selectedData; 
           
            if (_currentRound >= _data.roundsData.Length)
            {
                selectedData = _data.roundsData[Random.Range(0, _data.roundsData.Length)];
                _currentRoundEnemies = selectedData.GetTotalRoundEnemiesAmount();
            }
            else
            {
                selectedData = _data.roundsData[_currentRound];
                _currentRoundEnemies = selectedData.GetTotalRoundEnemiesAmount();
            }

            await Task.Delay(selectedData.delayToNextRound * _millisecondsInSecond);
            
            StartRound(selectedData);
        }
        
        private void IsRoundFinished()
        {
            if (_currentRoundEnemies <= 0)
            {
                OnRoundFinished?.Invoke();
                RoundPrepare();
            }
        }
    }
}