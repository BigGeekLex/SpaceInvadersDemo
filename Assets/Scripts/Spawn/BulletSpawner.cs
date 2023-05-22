using ShootLogic;
using UnityEngine;

namespace Spawn
{
    public class BulletSpawner : SpawnerBase<Bullet, BulletType>, IBulletSpawner
    {
        public BulletSpawner(SpawnDataBase<Bullet, BulletType> data, SimplePool simplePool) : base(data, simplePool)
        {
        }
        
        public GameObject SpawnBullet(Vector2 pos, BulletType bulletType = BulletType.Small, bool random = false)
        {
            return Spawn(pos, bulletType, random);
        }

        public void DespawnBullet(GameObject bullet)
        {
            Despawn(bullet);
        }
    }
}