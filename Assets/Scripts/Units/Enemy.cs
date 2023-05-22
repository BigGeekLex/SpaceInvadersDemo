using SimpleDImple;
using Spawn;

namespace Units
{
    public class Enemy : UnitBase
    {
        private IEnemySpawner _enemySpawner;

        [Injectable]
        public void Init(IEnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }
        protected override void OnUnitDeath()
        {
            _enemySpawner.DespawnEnemy(gameObject);
        }
    }
}