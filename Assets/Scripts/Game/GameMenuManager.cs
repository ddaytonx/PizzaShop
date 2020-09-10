using System;
using UnityEngine;
using UnityEngine.UI;

namespace PizzaShop.Game
{
    public class GameMenuManager : MonoBehaviour
    {
        [Header("Pause Menu UI")]
        public GameObject PauseMenuPanel;
        public Button ResumeGameBtn;
        public Button RestartGameBtn;
        public Button ExitGameBtn;

        [Header("Game UI")]
        public GameObject GamePanel;
        public InputField CutInputField;
        public Button CutButton;
        public Button SubmitButton;
        public Button PauseButton;

        [Header("Win UI")]
        public GameObject WMenuPanel;
        public Button WRestartGameBtn;
        public Button WExitGameBtn;

        [Header("Reference")]
        public LevelManager LevelManager;

        private void Start()
        {
            ResumeGame(false);

            if (ResumeGameBtn != null)
            {
                ResumeGameBtn.onClick.RemoveAllListeners();
                ResumeGameBtn.onClick.AddListener(ResumeGame);
            }

            if (RestartGameBtn != null)
            {
                RestartGameBtn.onClick.RemoveAllListeners();
                RestartGameBtn.onClick.AddListener(RestartGame);
            }

            if (ExitGameBtn != null)
            {
                ExitGameBtn.onClick.RemoveAllListeners();
                ExitGameBtn.onClick.AddListener(ExitGame);
            }

            if (CutButton != null)
            {
                CutButton.onClick.RemoveAllListeners();
                CutButton.onClick.AddListener(CutPizza);
            }

            if (CutInputField != null)
            {
                CutInputField.onEndEdit.RemoveAllListeners();
                CutInputField.onEndEdit.AddListener(ValidateNumber);
            }

            if (SubmitButton != null)
            {
                SubmitButton.onClick.RemoveAllListeners();
                SubmitButton.onClick.AddListener(SubmitPizza);
            }

            if (PauseButton != null)
            {
                PauseButton.onClick.RemoveAllListeners();
                PauseButton.onClick.AddListener(PauseGame);
            }

            if (WRestartGameBtn != null)
            {
                WRestartGameBtn.onClick.RemoveAllListeners();
                WRestartGameBtn.onClick.AddListener(RestartGame);
            }

            if (WExitGameBtn != null)
            {
                WExitGameBtn.onClick.RemoveAllListeners();
                WExitGameBtn.onClick.AddListener(ExitGame);
            }
        }

        private void SubmitPizza()
        {
            AudioManager.ButtonClicked();
            var finsihedLevel = LevelManager.CustomerHandler.FinishCustomer();
            if (finsihedLevel)
            {
                AudioManager.Win();
                GamePanel.SetActive(false);
                WMenuPanel.SetActive(true);
            }
            else LevelManager.PizzaHandler.CutIntoPeices(1);
        }

        private void ValidateNumber(string arg0)
        {
            int.TryParse(arg0, out int peices);
            peices = peices < 1 ? 1 : peices > 5 ? 5 : peices;
            CutInputField.text = peices.ToString();
        }

        private void CutPizza()
        {
            AudioManager.Sliced();
            LevelManager.CustomerHandler.ResetCustomerNeeds();
            int.TryParse(CutInputField.text, out int peices);
            peices = peices < 1 ? 1 : peices > 5 ? 5 : peices;
            LevelManager.PizzaHandler.CutIntoPeices(peices);
        }

        private void RestartGame()
        {
            AudioManager.ButtonClicked();
            GameManager.LoadGame();
            //GameManager.PauseGame = false;
        }

        private void ExitGame()
        {
            GameManager.QuitGame();
        }
        private void ResumeGame()
        {
            GamePanel.SetActive(true);
            PauseMenuPanel.SetActive(false);
            AudioManager.ButtonClicked();
        }

        private void ResumeGame(bool audio)
        {
            GamePanel.SetActive(true);
            PauseMenuPanel.SetActive(false);
            if (audio) AudioManager.ButtonClicked();
        }

        public void PauseGame()
        {
            AudioManager.ButtonClicked();
            PauseMenuPanel.SetActive(true);
            GamePanel.SetActive(false);
            //GameManager.PauseGame = true;
        }
    }
}
