using System;
using System.Collections.Generic;
using UnityEngine;

namespace HealthLogic
{
    public class HPBase : MonoBehaviour, IDamagable
    {
        [SerializeField] private float maxHP = 1;
    
    
        private float _currentHP;
        private float _damageFactor = 1.0f;

        private List<Func<float, float>> _damageFactors = new List<Func<float, float>>();
    
        public event Action OnDeath;
        public float GetMaxHealth => maxHP;

        public bool TryDamage(float value)
        {
            if(_damageFactor <= 0.0f) return false;
        
            _currentHP -= value * _damageFactor;

            if (_currentHP <= 0)
            {
                Die();
            }
        
            return true;
        }
    
        public void AddDamageFactor(Func<float, float> factor)
        {
            _damageFactors.Add(factor);
            _damageFactor = CalculateDamageFactor(_damageFactor);
        }

        private void OnEnable()
        {
            _currentHP = maxHP;
        }
        private float CalculateDamageFactor(float value)
        {
            for (int i = 0; i < _damageFactors.Count; i++)
            {
                value = _damageFactors[i].Invoke(value);
            }
            return value;
        }
        private void Die()
        {
            OnDeath?.Invoke();
        }
    }
}
