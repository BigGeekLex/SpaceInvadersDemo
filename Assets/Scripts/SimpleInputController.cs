using Movement;
using UnityEngine;

public class SimpleInputController : MonoBehaviour
{
    [SerializeField] private string verticalAxisName = "Vertical";
    [SerializeField] private string horizontalAxisName = "Horizontal";
    
    private IMovable _movable;

    private void Awake()
    {
        _movable = GetComponent<IMovable>();
    }
    private void Update()
    {
        var vertical = Input.GetAxis(verticalAxisName);
        var horizontal = Input.GetAxis(horizontalAxisName);
        
        _movable.SetDirection(new Vector2(horizontal, vertical));
    }
}

