using ShootLogic;
using Spawn;
using UnityEngine;

namespace Ability
{
    public class ChangeBulletAbility : AbilityBase
    {
        [SerializeField] 
        private BulletType bulletType;

        private void Awake()
        {
            OnAwake();
        }

        protected override void Activate(GameObject sender)
        {
            IShootable shootable = sender.GetComponent<IShootable>();
            shootable.ChangeBulletType(bulletType);
        }
    }
}