using Ability;
using UnityEngine;

namespace Spawn
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AbilitySpawnData", order = 1)]
    public class AbilitySpawnData : SpawnDataBase<AbilityBase, AbilityType>
    {
       
    }
}