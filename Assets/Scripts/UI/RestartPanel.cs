using GameStatement;
using SimpleDImple;
using UnityEngine;

namespace UI
{
    public class RestartPanel : MonoBehaviour
    {
        [SerializeField] private GameObject restartPanel;

        private IGameStateController _gameStateController;
        private void Awake()
        {
            restartPanel.SetActive(false);
        }

        [Injectable]
        private void Init(IGameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _gameStateController.OnGameStateChanged += OnGameLoosed;
        }

        private void OnGameLoosed(GameState gameState)
        {
            if(gameState != GameState.Loose) return;
            ShowRestartPanel();
        }
    
        private void OnDestroy()
        {
            _gameStateController.OnGameStateChanged -= OnGameLoosed;
        }
        private void ShowRestartPanel()
        {
            restartPanel.SetActive(true);
        }
    }
}
