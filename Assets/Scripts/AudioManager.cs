using UnityEngine;

namespace PizzaShop
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager audioManager;
        private AudioSource Source;

        [SerializeField] private AudioClip buttonClicked = null;
        [SerializeField] private AudioClip win = null;
        [SerializeField] private AudioClip pizzaSilced = null;
        [SerializeField] private AudioClip success = null;
        [SerializeField] private AudioClip give = null;

        private void Awake()
        {
            if (audioManager == null) audioManager = this;
            else Destroy(this);
        }

        private void Start()
        {
            Source = GetComponent<AudioSource>();
        }

        private static void PlayClip(AudioClip clip)
        {
            Stop();
            audioManager.Source.clip = clip;
            audioManager.Source.Play();
        }

        public static void ButtonClicked() => PlayClip(audioManager.buttonClicked);
        public static void Win() => PlayClip(audioManager.win);
        public static void Sliced() => PlayClip(audioManager.pizzaSilced);
        public static void Success() => PlayClip(audioManager.success);
        public static void Give() => PlayClip(audioManager.give);
        public static void Stop() => audioManager.Source.Stop();

    }
}
