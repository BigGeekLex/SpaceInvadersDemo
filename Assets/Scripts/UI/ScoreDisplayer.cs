using LevelControllers;
using SimpleDImple;
using TMPro;
using UnityEngine;
using Utilities;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI), typeof(SimpleScaler))]
    public class ScoreDisplayer : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshProUGUI;
        private SimpleScaler _simpleScaler;
        private IScoreController _scoreController;
 
        private const string _scorePrefix = "Score: {0}";
    
        [Injectable]
        public void Init(IScoreController scoreController)
        {
            _scoreController = scoreController;
            _scoreController.OnScoreChanged += OnScoreChanged;
        }
        private void OnScoreChanged(int score)
        {
            _textMeshProUGUI.text = string.Format(_scorePrefix, score);
            _simpleScaler.DoScale();
        }
        private void Awake()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            _simpleScaler = GetComponent<SimpleScaler>();
            _textMeshProUGUI.text = string.Format(_scorePrefix, 0);
        }
        private void OnDestroy()
        {
            _scoreController.OnScoreChanged -= OnScoreChanged;
        }
    }
}
