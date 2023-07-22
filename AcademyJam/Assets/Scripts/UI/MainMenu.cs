using Audio;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;

        private void Awake()
        {
            _audioManager.PlayMusic();
        }

        public void PlayGame()
        {
            _audioManager.PlayButtonSfx();
            DontDestroyOnLoad(_audioManager.gameObject);
            SceneLoader.Instance.LoadNextScene();
            DontDestroyOnLoad(SceneLoader.Instance);
        }

        public void SetMusicSlider(float volume)
        {
            _audioManager.PlayButtonSfx();
            _audioManager.SetMusicVolume(volume);
        }

        public void SetSFXSlider(float volume)
        {
            _audioManager.PlayButtonSfx();
            _audioManager.SetSfxVolume(volume);
        }
    }
}