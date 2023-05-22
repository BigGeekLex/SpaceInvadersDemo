using ShootLogic;
using UnityEngine;

namespace Spawn
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletSpawnData", order = 1)]
    public class BulletSpawnData : SpawnDataBase<Bullet, BulletType>
    {
       
    }
}