using GameplaySettings;
using SimpleDImple;
using Spawn;
using UnityEngine;

namespace LevelControllers
{
    public class EnemyRoundSpawner : MonoBehaviour
    {
        private int _spawnEnemyAmount;

        private IEnemySpawner _enemySpawner;
        private ISpawnPlacer _spawnPlacer;
        private IRoundController _roundController;

        [Injectable]
        public void Init(IEnemySpawner enemySpawner, ISpawnPlacer spawnPlacer, IRoundController roundController)
        {
            _enemySpawner = enemySpawner;
            _spawnPlacer = spawnPlacer;
            _roundController = roundController;
            _roundController.OnRoundStarted += OnRoundStarted;
        }
        private void OnRoundStarted(int round, RoundData roundData)
        {
            SpawnEnemies(roundData);
        }
        private void SpawnEnemies(RoundData roundData)
        {
            int index = 0;
            for (int i = 0; i < roundData.enemiesToSpawn.Length; i++)
            {
                for (int j = 0; j < roundData.enemiesToSpawn[i].amount; j++)
                {
                    Vector2 nextPosition = _spawnPlacer.GetPossiblePositionByIndex(index);
                    _enemySpawner.SpawnEnemy(nextPosition, roundData.enemiesToSpawn[i].enemyType);
                    index++;
                }
            }
        }

        private void OnDestroy()
        {
            _roundController.OnRoundStarted -= OnRoundStarted;
        }
    }
}
