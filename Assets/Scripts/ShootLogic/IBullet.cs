using UnityEngine;

namespace ShootLogic
{
    public interface IBullet
    {
        void Initialize(Vector2 moveDirection, string[] targetTags);
    }
}