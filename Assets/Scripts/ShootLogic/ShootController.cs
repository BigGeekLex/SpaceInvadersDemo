using System;
using SimpleDImple;
using Spawn;
using UnityEngine;

namespace ShootLogic
{
    public class ShootController : MonoBehaviour, IShootable
    {
        [SerializeField] private float delayBetweenShoots = 0.25f;
        [SerializeField] private Transform bulletShootTr;
        [SerializeField] private Vector2 shootDirection;
        [SerializeField] private string[] targetTags;
    
        private BulletType _targetBulletType = BulletType.Small;
        private IBulletSpawner _bulletSpawner;
        private float _currentDelay;
    
        public event Action OnBulletTypeChanged;
    
        [Injectable]
        public void Init(IBulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
        }
        private void Update()
        {
            _currentDelay += Time.deltaTime;
        
            if (_currentDelay >= delayBetweenShoots)
            {
                Shoot();
                _currentDelay = 0.0f;
            }
        }
        private void Shoot()
        {
            var spawnedBullet = _bulletSpawner.SpawnBullet(new Vector2(bulletShootTr.position.x, bulletShootTr.position.y), _targetBulletType);
 
            IBullet bullet = spawnedBullet.GetComponent<IBullet>();
            bullet.Initialize(shootDirection, targetTags);
        }
        public void ChangeBulletType(BulletType bulletType)
        {
            _targetBulletType = bulletType;
            OnBulletTypeChanged?.Invoke();
        }
    }
}