using System;
using Spawn;

namespace ShootLogic
{
    public interface IShootable
    {
        event Action OnBulletTypeChanged;
        void ChangeBulletType(BulletType bulletType);
    }
}