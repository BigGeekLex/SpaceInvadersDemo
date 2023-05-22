using Ability;
using SimpleDImple;
using Spawn;
using UnityEngine;

namespace LevelControllers
{
    public class AbilityEnemyDeathSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnChance = 0.1f;
        
        private IEnemySpawner _enemySpawner;
        private IAbilitySpawner _abilitySpawner;
        private AbilitySpawnData _abilitySpawnData;
        
        [Injectable]
        public void Init(IEnemySpawner enemySpawner, IAbilitySpawner abilitySpawner, AbilitySpawnData abilitySpawnData)
        {
            _enemySpawner = enemySpawner;
            _abilitySpawner = abilitySpawner;
            _abilitySpawnData = abilitySpawnData;
            _enemySpawner.OnEnemyDespawned += TryToSpawnAbility;
        }
        private void TryToSpawnAbility(Vector2 enemyDeathPos)
        {
            float random = Random.Range(0.0f, 1.0f);

            if (spawnChance >= random)
            {
                var selectedAbility = _abilitySpawnData.spawnObjects[Random.Range(0, _abilitySpawnData.spawnObjects.Length)];
                _abilitySpawner.SpawnAbility(enemyDeathPos, selectedAbility.selectionType);
            }
        }
        private void OnDestroy()
        {
            _enemySpawner.OnEnemyDespawned -= TryToSpawnAbility;
        }
    }
}