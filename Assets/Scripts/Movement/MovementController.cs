using SimpleDImple;
using UnityEngine;
using Utilities;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour, IMovable
    {
        [SerializeField]
        private bool ignoreBound = false;
        [SerializeField]
        private float movementSpeed;
    
        private Rigidbody2D _rb;

        private IScreenBound _screenBound;
        private Vector2 _dir;
    
        [Injectable]
        public void Init(IScreenBound screenBound)
        {
            _screenBound = screenBound;
        }
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if(_dir == Vector2.zero) return;
        
            Vector2 nextMovePosition; 
        
            if (!ignoreBound)
            {
                var nextHorizontalValue = Mathf.Clamp(_rb.position.x + movementSpeed * Time.fixedDeltaTime * _dir.x,
                    _screenBound.GetBound().x, _screenBound.GetBound().x * -1);
                var nextVerticalValue = Mathf.Clamp(_rb.position.y + movementSpeed * Time.fixedDeltaTime * _dir.y,
                    _screenBound.GetBound().y, _screenBound.GetBound().y * -1);   
                nextMovePosition = new Vector2(nextHorizontalValue, nextVerticalValue);
            }
            else
            {
                nextMovePosition = _rb.position + movementSpeed * Time.fixedDeltaTime * _dir;
            }
        
            _rb.MovePosition(nextMovePosition);
        }

        public void SetDirection(Vector2 dir)
        {
            _dir = dir;
        }
    }
}