using Spawn;
using UnityEngine;

namespace Ability
{
    public class AbilitySpawner : SpawnerBase<AbilityBase, AbilityType>, IAbilitySpawner
    {
        public AbilitySpawner(SpawnDataBase<AbilityBase, AbilityType> data, SimplePool simplePool) : base(data, simplePool)
        {
        }

        public GameObject SpawnAbility(Vector2 pos, AbilityType abilityType = AbilityType.BulletSmall, bool random = false)
        {
            return Spawn(pos, abilityType, random);
        }

        public void DespawnAbility(GameObject ablility)
        {
            Despawn(ablility);
        }
    }
}