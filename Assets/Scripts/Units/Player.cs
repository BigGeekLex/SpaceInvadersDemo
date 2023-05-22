using GameStatement;
using SimpleDImple;
using UnityEngine;

namespace Units
{
    public class Player : UnitBase
    {
        private IGameStateController _gameStateController;
        
        [Injectable]
        public void Init(IGameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }
        
        private void Awake()
        {
            OnAwake();
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(GameConstants.enemyTag))
            {
                _hpBase.TryDamage(_hpBase.GetMaxHealth);
            }
        }
        protected override void OnUnitDeath()
        {
            _gameStateController.SetGameState(GameState.Loose);
            Destroy(gameObject);
        }
    }
}