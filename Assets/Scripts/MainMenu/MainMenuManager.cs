using UnityEngine;
using UnityEngine.UI;

namespace PizzaShop.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public Button StartGameBtn;
        public Button ExitGameBtn;

        private void Start()
        {
            if (StartGameBtn != null)
            {
                StartGameBtn.onClick.RemoveAllListeners();
                StartGameBtn.onClick.AddListener(StartGame);
            }

            if (ExitGameBtn != null)
            {
                ExitGameBtn.onClick.RemoveAllListeners();
                ExitGameBtn.onClick.AddListener(ExitGame);
            }
        }

        private void ExitGame()
        {
            GameManager.QuitGame();
        }

        private void StartGame()
        {
            AudioManager.ButtonClicked();
            GameManager.LoadGame();
        }
    }
}