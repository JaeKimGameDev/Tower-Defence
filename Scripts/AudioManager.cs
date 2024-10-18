using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider masterSoundSlider;
    [SerializeField] private Slider musicSoundSlider;
    [SerializeField] private Slider effectsSoundSlider;
    private int masterValue=1, musicValue=1, effectsValue=1;
    public GameObject masterBarrierOn;
    public GameObject musicBarrierOn;
    public GameObject effectsBarrierOn;
    public GameObject masterBarrierOff;
    public GameObject musicBarrierOff;
    public GameObject effectsBarrierOff;

    public AudioMixer mixer;

    void Start()
    {
        CheckMaster();
    }

    public void SetAudioLevel(float audioLevel)
    {
        mixer.SetFloat("music", Mathf.Log10(audioLevel) * 20);
    }
    public void ChangeMasterVolume()
    {
        AudioListener.volume = masterSoundSlider.value;
        PlayerPrefs.SetFloat("masterVolume", masterSoundSlider.value);
        SetAudioLevel(masterSoundSlider.value);
    }
    public void ChangeMusicVolume()
    {
        AudioListener.volume = musicSoundSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicSoundSlider.value);
    }
    public void ChangeEffectsVolume()
    {
        AudioListener.volume = effectsSoundSlider.value;
        PlayerPrefs.SetFloat("effectsVolume", effectsSoundSlider.value);
    }
    public void MasterVolumeOnOff()
    {
        if (masterValue == 1)
        {
            masterValue = 0;
        }
        else
        {
            masterValue = 1;
        }
        PlayerPrefs.SetInt("masterOnOff", masterValue);
        SetMasterBarrier();
    }
    public void MusicVolumeOnOff()
    {
        if (musicValue == 1)
        {
            musicValue = 0;
        }
        else
        {
            musicValue = 1;
        }
        PlayerPrefs.SetInt("musicOnOff", musicValue);
        SetMusicBarrier();
    }
    public void EffectsVolumeOnOff()
    {
        if (effectsValue == 1)
        {
            effectsValue = 0;
        }
        else
        {
            effectsValue = 1;
        }
        PlayerPrefs.SetInt("effectsOnOff", effectsValue);
        SetEffectsBarrier();
    }
    public void SetMasterBarrier()
    {
        if (PlayerPrefs.GetInt("masterOnOff") == 1)
        {
            masterBarrierOn.SetActive(true);
            masterBarrierOff.SetActive(false);
        }
        else
        {
            masterBarrierOn.SetActive(false);
            masterBarrierOff.SetActive(true);
        }
    }
    public void SetMusicBarrier()
    {
        if (PlayerPrefs.GetInt("musicOnOff") == 1)
        {
            musicBarrierOn.SetActive(true);
            musicBarrierOff.SetActive(false);
        }
        else
        {
            musicBarrierOn.SetActive(false);
            musicBarrierOff.SetActive(true);
        }
    }
    public void SetEffectsBarrier()
    {
        if (PlayerPrefs.GetInt("effectsOnOff") == 1)
        {
            effectsBarrierOn.SetActive(true);
            effectsBarrierOff.SetActive(false);
        }
        else
        {
            effectsBarrierOn.SetActive(false);
            effectsBarrierOff.SetActive(true);
        }
    }
    private void CheckMaster()
    {
        // no file to load
        if (!PlayerPrefs.HasKey("masterVolume"))
        {
            Save();
        }
        Load();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("masterVolume", 1);
        PlayerPrefs.SetInt("masterOnOff", 1);
        PlayerPrefs.SetFloat("musicVolume", 1);
        PlayerPrefs.SetInt("musicOnOff", 1);
        PlayerPrefs.SetFloat("effectsVolume", 1);
        PlayerPrefs.SetInt("effectsOnOff", 1);
    }
    public void Load()
    {
        masterSoundSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSoundSlider.value = PlayerPrefs.GetFloat("musicVolume");
        effectsSoundSlider.value = PlayerPrefs.GetFloat("effectsVolume");
        masterValue = PlayerPrefs.GetInt("masterOnOff");
        musicValue = PlayerPrefs.GetInt("musicOnOff");
        effectsValue = PlayerPrefs.GetInt("effectsOnOff");
        SetMasterBarrier();
        SetMusicBarrier();
        SetEffectsBarrier();
        //ChangeMasterVolume();
        //ChangeMusicVolume();
        //ChangeEffectsVolume();
    }
}
