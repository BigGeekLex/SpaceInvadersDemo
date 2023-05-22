using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class SimplePool
    {
        private Dictionary<string, Queue<GameObject>> _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            GameObject nextGO;
            
            if (TryGetFromPool(prefab.name, out GameObject go))
            {
                go.transform.position = position;
                go.transform.rotation = rotation;
                go.SetActive(true);
                nextGO = go;
            }
            else
            {
                nextGO = Object.Instantiate(prefab, position, rotation);
                nextGO.name = prefab.name;
                AddToPool(nextGO);
            }

            return nextGO;
        }

        public void Despawn(GameObject gameObject)
        {
            gameObject.SetActive(false);
            AddToPool(gameObject);
        }

        public void Preload(GameObject prefab, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var nextGO = Object.Instantiate(prefab);
                nextGO.SetActive(false);
                AddToPool(nextGO);
            }
        }

        private void AddToPool(GameObject pooledGO)
        {
            if (_poolDictionary.ContainsKey(pooledGO.name))
            {
                _poolDictionary[pooledGO.name].Enqueue(pooledGO);
            }
            else
            {
                _poolDictionary.Add(pooledGO.name, new Queue<GameObject>());
                _poolDictionary[pooledGO.name].Enqueue(pooledGO);
            }
        }
        
        private bool TryGetFromPool(string name, out GameObject gameObject)
        {
            gameObject = null;
            
            if (_poolDictionary.ContainsKey(name))
            {
                if (_poolDictionary[name].Count > 0)
                {
                    if (_poolDictionary[name].Peek().activeSelf) return false;
                    
                    gameObject = _poolDictionary[name].Dequeue();
                    return true;
                }
            }

            gameObject = null;
            return false;
        }
    }
}