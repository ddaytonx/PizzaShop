using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PizzaShop
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
            else Destroy(gameObject);
        }

        public static void LoadGame() => instance.LoadgameI();
        public static void QuitGame() => instance.QuitGameI();

        private void LoadgameI()
        {
            SceneManager.LoadScene(1);
        }

        private void QuitGameI()
        {
            StartCoroutine("Quit");
        }

        private IEnumerator Quit()
        {
            yield return new WaitForEndOfFrame();

            try
            {
                Application.Quit();
            }
            catch (System.Exception)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}
