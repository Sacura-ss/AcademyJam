using Audio;
using Saving;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private Button _resumeButton;
        private DataSaver _dataSaver;

        private Color _resumeButtonColor;
        private void Awake()
        {
            //_audioManager.PlayMusic();
            _dataSaver = FindObjectOfType<DataSaver>();
            _resumeButtonColor = _resumeButton.GetComponent<Image>().color;
        }

        private void Start()
        {
            DontDestroyOnLoad(_dataSaver);
            DontDestroyOnLoad(_audioManager.gameObject);
            DontDestroyOnLoad(SceneLoader.Instance);
            
            if (_dataSaver.savedData.LevelPart == 1)
            {
                DisableButton(_resumeButton);
            }
            else
            {
                EnableButton(_resumeButton);
            }
        }

        public void PlayGame()
        {
            _audioManager.PlayButtonSfx();
            SceneLoader.Instance.LoadSceneByBuildIndex(1);
            _dataSaver.ClearInfo();
        }

        public void ResumeGame()
        {
            _audioManager.PlayButtonSfx();
            SceneLoader.Instance.LoadSceneByBuildIndex(_dataSaver.savedData.LevelPart);
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
        
        private void EnableButton(Button button)
        {
            button.GetComponent<Image>().color = _resumeButtonColor;
            button.enabled = true;
        }

        private void DisableButton(Button button)
        {
            button.GetComponent<Image>().color = Color.gray;
            button.enabled = false;
        }
    }
}
