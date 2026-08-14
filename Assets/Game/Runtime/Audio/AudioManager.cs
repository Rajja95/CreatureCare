using UnityEngine;

namespace CreatureCare.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Audio Clips")]
        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioClip buttonClick;
        [SerializeField] private AudioClip stateChange;
        [SerializeField] private AudioClip win;
        [SerializeField] private AudioClip lose;

        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource effectsSource;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            PlayBackgroundMusic();
        }

        public void PlayButtonClick()
        {
            PlayEffect(buttonClick);
        }

        public void PlayStateChange()
        {
            PlayEffect(stateChange);
        }

        public void PlayWin()
        {
            PlayEffect(win);
        }

        public void PlayLose()
        {
            PlayEffect(lose);
        }

        private void PlayBackgroundMusic()
        {
            if (backgroundMusic == null)
            {
                return;
            }

            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }

        private void PlayEffect(AudioClip clip)
        {
            if (clip == null)
            {
                return;
            }

            effectsSource.PlayOneShot(clip);
        }
    }
}