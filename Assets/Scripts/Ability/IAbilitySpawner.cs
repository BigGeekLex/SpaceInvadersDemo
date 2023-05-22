using UnityEngine;

namespace Ability
{
    public interface IAbilitySpawner
    {
        GameObject SpawnAbility(Vector2 pos, AbilityType abilityType = AbilityType.BulletSmall, bool random = false);

        void DespawnAbility(GameObject ability);
    }
}