using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public abstract class SpawnerBase<T, U>  where T : MonoBehaviour where U : Enum
    {
        protected readonly SpawnDataBase<T,U> _data;
        protected readonly SimplePool _simplePool;
        
        public SpawnerBase(SpawnDataBase<T,U> data, SimplePool simplePool)
        {
            if (data == null) throw new NullReferenceException("Data Container is null");
            _data = data;
            _simplePool = simplePool;
        }
        
        protected virtual GameObject Spawn(Vector2 pos, U selectionType, bool random = false)
        {
            GameObject selectedPrefab = null;

            if (random)
            {
                selectedPrefab = _data.spawnObjects[Random.Range(0, _data.spawnObjects.Length)].prefab.gameObject;
            }
            else
            {
                selectedPrefab = _data.spawnObjects.FirstOrDefault((x) => 
                    x.selectionType.Equals(selectionType))?.prefab.gameObject;
            }
            var spawnedGO = _simplePool.Spawn(selectedPrefab, pos, Quaternion.identity);

            return spawnedGO;
        }

        protected virtual void Despawn(GameObject despawnedObj)
        {
            _simplePool.Despawn(despawnedObj);
        }
    }
}
