using System;
using Spawn;
using UnityEngine;

namespace GameplaySettings
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoundData", order = 1)]
    public class RoundsData : ScriptableObject
    {
        public RoundData[] roundsData;
    }
    
    
    [Serializable]
    public class RoundData
    {
        public int delayToNextRound;
        public RoundEnemyData[] enemiesToSpawn;
        
        public int GetTotalRoundEnemiesAmount()
        {
            int enemies = 0;
            
            for (int i = 0; i < enemiesToSpawn.Length; i++)
            {
                enemies += enemiesToSpawn[i].amount;
            }

            return enemies;
        }
    }
    
    [Serializable]
    public class RoundEnemyData
    {
        public EnemyType enemyType;
        public int amount;
    }
}