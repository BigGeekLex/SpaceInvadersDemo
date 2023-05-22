using DG.Tweening;
using UnityEngine;

namespace Utilities
{
    public class SimpleScaler : MonoBehaviour
    {
        [SerializeField] private float scaleDuration = 0.15f;
        [SerializeField] private float scaleFactor = 0.8f;

        private Vector3 _initialScale;
        private Vector3 _scaleTo;
        private void Awake()
        {
            _initialScale = transform.localScale;
            if (_initialScale != Vector3.zero)
            {
                _scaleTo = _initialScale * scaleFactor;
            }
            else
            {
                _scaleTo = _initialScale + Vector3.one;
            }
        }
    
        public void DoScale()
        {
            transform.DOScale(_scaleTo, scaleDuration).OnComplete(()=> transform.DOScale(_initialScale, scaleDuration));
        }
    }
}