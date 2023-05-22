using System;

namespace HealthLogic
{
    public interface IDamagable
    {
        event Action OnDeath;
        void AddDamageFactor(Func<float, float> factor);
        bool TryDamage(float value);
    }
}