using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class RestartLevelButton : MonoBehaviour
    {
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(()=> SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        }
    }
}
