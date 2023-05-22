using System;
using UnityEngine;

namespace Spawn
{
    public interface IEnemySpawner
    {
        event Action OnEnemySpawned;
        event Action<Vector2> OnEnemyDespawned;
        GameObject SpawnEnemy(Vector2 pos, EnemyType enemyType = EnemyType.Default, bool random = false);
        void DespawnEnemy(GameObject enemy);
    }

    public interface IBulletSpawner
    {
        GameObject SpawnBullet(Vector2 pos, BulletType bulletType = BulletType.Small, bool random = false);

        void DespawnBullet(GameObject bullet);
    }
}