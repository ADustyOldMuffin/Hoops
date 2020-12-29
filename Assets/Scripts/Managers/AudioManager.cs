using System;
using System.Collections;
using Constants;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        [Header("SFX")] 
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioClip buzzerAudioClip;

        [Header("Music")] 
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioClip mainBackgroundMusic;
        
        [Header("Settings")]
        [SerializeField] private float volume = 0.5f;

        public IEnumerator PlayClipAtPoint(Vector3 location, HoopsAudioClip audioClip)
        {
            AudioClip clip;

            switch (audioClip)
            {
                case HoopsAudioClip.Buzzer:
                    clip = buzzerAudioClip;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(audioClip), audioClip, null);
            }
            
            AudioSource.PlayClipAtPoint(clip, location, volume);
            yield return null;
        }

        public IEnumerator PlayMusic(HoopsMusic audioClip, bool loop)
        {
            AudioClip clip;

            switch (audioClip)
            {
                case HoopsMusic.MainBackground:
                    clip = mainBackgroundMusic;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(audioClip), audioClip, null);
            }

            musicSource.Stop();
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.volume = .25f;
            musicSource.Play();
            yield return null;
        }

        public void SetVolumeLevel(float newVolume)
        {
            volume = newVolume;
        }
    }
}