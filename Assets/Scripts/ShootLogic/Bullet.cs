using System.Linq;
using HealthLogic;
using Movement;
using SimpleDImple;
using Spawn;
using UnityEngine;

namespace ShootLogic
{
    [RequireComponent(typeof(MovementController))]
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private float despawnTime = 1.5f;
        [SerializeField] private int damage = 1;
        
        private string[] _targetTags;
        private IMovable _movable;
        
        private IBulletSpawner _bulletSpawner;
        private float _currentActiveTime = 0.0f;

        private void Awake()
        {
            _movable = GetComponent<IMovable>();
        }

        private void OnEnable()
        {
            _currentActiveTime = 0.0f;
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_targetTags.Contains(col.tag))
            {
                IDamagable damagable;
                if (col.TryGetComponent(out damagable))
                {
                    damagable.TryDamage(damage);
                    _bulletSpawner.DespawnBullet(gameObject);
                }   
            }
        }

        [Injectable]
        public void Init(IBulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
        }
        private void Update()
        {
            _currentActiveTime += Time.deltaTime;
            
            if (_currentActiveTime >= despawnTime)
            {
                _bulletSpawner.DespawnBullet(this.gameObject);
            }
        }

        public void Initialize(Vector2 moveDirection, string[] targetTags)
        {
            _movable.SetDirection(moveDirection);
            _targetTags = targetTags;
        }
    }
}