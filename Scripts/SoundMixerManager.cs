using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        level = -80 + (.8f * level);
        audioMixer.SetFloat("MasterVolume", level);
    }
    public void SetMusicVolume(float level)
    {
        level = -80 + (.8f * level);
        audioMixer.SetFloat("MusicVolume", level);
    }
    public void SetEffectsVolume(float level)
    {
        level = -80 + (.8f * level);
        audioMixer.SetFloat("SoundFXVolume", level);
    }
}
