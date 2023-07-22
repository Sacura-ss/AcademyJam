using Audio;
using UnityEngine;

namespace UI
{
    public class ButtonHandler : MonoBehaviour
    {
        private AudioManager _audioManager;

        private void Awake()
        {
            _audioManager = FindObjectOfType<AudioManager>();
        }
        
        public void BackToMenu(float volume)
        {
            _audioManager.PlayButtonSfx();
            SceneLoader.Instance.LoadMainMenu();
            _audioManager.StopMusic();
        }

        public void Help()
        {
            // we cant help you 
        }

        public void LoadNextPart()
        {
            _audioManager.PlayButtonSfx();
            SceneLoader.Instance.LoadNextScene();
        }
    }
}
