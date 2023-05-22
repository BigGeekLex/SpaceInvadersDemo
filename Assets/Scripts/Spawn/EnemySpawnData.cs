using System;
using JetBrains.Annotations;
using Units;
using UnityEngine;

namespace Spawn
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemySpawnData", order = 1)]
    public class EnemySpawnData : SpawnDataBase<Enemy, EnemyType>
    {
        
    }
    public abstract class SpawnDataBase<T,U> : ScriptableObject where U : Enum where T : MonoBehaviour
    {
        public SpawnObjectBase<T, U>[] spawnObjects;
    }
    
    [Serializable]
    public class SpawnObjectBase<T, U> where T : MonoBehaviour where U : Enum
    {
        public U selectionType;
        public T prefab;
    }
    public enum EnemyType
    {
        Default,
        Allien
    }
}