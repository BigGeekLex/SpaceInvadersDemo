using Movement;
using SimpleDImple;
using UnityEngine;

namespace Ability
{
    [RequireComponent(typeof(MovementController))]
    public abstract class AbilityBase : MonoBehaviour
    {
        [SerializeField] private string targetObjectTag = "Player";
        protected IMovable _movable;

        private IAbilitySpawner _abilitySpawner;

        [Injectable]
        public void Init(IAbilitySpawner abilitySpawner)
        {
            _abilitySpawner = abilitySpawner;
        }
        
        protected virtual void OnAwake()
        {
            _movable = GetComponent<IMovable>();
            _movable.SetDirection(Vector2.down);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(targetObjectTag))
            {
                Activate(col.gameObject);
                _abilitySpawner?.DespawnAbility(gameObject);
            }
        }

        protected abstract void Activate(GameObject sender);
    }
}