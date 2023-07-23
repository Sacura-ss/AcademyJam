using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        [SerializeField] private AudioSource _music;
        [SerializeField] private AudioSource _buttonSFX;
        [SerializeField] private AudioSource _dropSFX;
        [SerializeField] private AudioSource _winSFX;
    

        private const string MIXER_MUSIC = "MusicVolume";
        private const string MIXER_SFX = "SFXVolume";
    

        private void Awake()
        {
            _music = GetComponentInChildren<AudioSource>();
        }

        public void SetMusicVolume(float value)
        {
            _audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        }

        public void SetSfxVolume(float value)
        {
            _audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
            _buttonSFX.Play();
        }

        public void PlayMusic()
        {
            _music.Play();
        }

        public void PlayButtonSfx()
        {
            _buttonSFX.Play();
        }

        public void PlayDropSfx()
        {
            _dropSFX.Play();
        }

        public void PlayWinSfx()
        {
            _winSFX.Play();
        }

        public void StopMusic()
        {
            _music.Stop();
        }
    }
}