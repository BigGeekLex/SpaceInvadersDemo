using UnityEngine;

namespace Utilities
{
    public class ScreenBound : IScreenBound
    {
        private readonly Camera _camera;
        
        public Vector2Int bounds;

        public ScreenBound(Camera camera)
        {
            _camera = camera;
            var tmp = _camera.ScreenToWorldPoint(new Vector3(Screen.width, (int)Screen.height,
                _camera.transform.position.z));
            
            bounds = new Vector2Int((int)tmp.x, (int)tmp.y);
        }

        public Vector2Int GetBound()
        {
            return bounds;
        }
    }
}