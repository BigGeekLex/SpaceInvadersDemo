using HealthLogic;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(HPBase))]
    public abstract class UnitBase : MonoBehaviour
    {
        protected HPBase _hpBase;
        
        protected virtual void OnAwake()
        {
            _hpBase = GetComponent<HPBase>();
            _hpBase.OnDeath += OnUnitDeath;
        }

        protected virtual void OnDestroy()
        {
            _hpBase.OnDeath -= OnUnitDeath;
        }

        protected abstract void OnUnitDeath();
    }
}