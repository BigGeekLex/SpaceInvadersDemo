using System;
using Units;
using UnityEngine;

namespace Spawn
{
    public class EnemySpawner : SpawnerBase<Enemy, EnemyType>, IEnemySpawner
    {
        public event Action OnEnemySpawned;
        public event Action<Vector2> OnEnemyDespawned;

        public EnemySpawner(SpawnDataBase<Enemy, EnemyType> data, SimplePool simplePool) : base(data, simplePool)
        {
        }
        public GameObject SpawnEnemy(Vector2 pos, EnemyType enemyType = EnemyType.Default, bool random = false)
        {
            GameObject spawnedGo = Spawn(pos, enemyType, random);
            OnEnemySpawned?.Invoke();
            
            return spawnedGo;
        }

        public void DespawnEnemy(GameObject enemy)
        {
            Despawn(enemy);
            OnEnemyDespawned?.Invoke(enemy.transform.position);
        }
    }
}