using GameplaySettings;
using LevelControllers;
using SimpleDImple;
using TMPro;
using UnityEngine;
using Utilities;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI), typeof(SimpleScaler))]
    public class RoundDisplayer : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshProUGUI;
        private IRoundController _roundController;
        private SimpleScaler _simpleScaler;
 
        private const string _roundStartedPrefix = "Round: {0}";

        [Injectable]
        public void Init(IRoundController roundController)
        {
            _roundController = roundController;
            _roundController.OnRoundStarted += OnRoundStarted;
        }
        private void OnRoundStarted(int round, RoundData data)
        {
            _textMeshProUGUI.text = string.Format(_roundStartedPrefix, round);
            _simpleScaler.DoScale();
        }
    
        private void Awake()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            _simpleScaler = GetComponent<SimpleScaler>();
        }
        private void OnDestroy()
        {
            _roundController.OnRoundStarted -= OnRoundStarted;
        }
    }
}