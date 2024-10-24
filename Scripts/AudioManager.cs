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
    [SerializeField] private AudioMixer audioMixer;
    public GameObject optionMenu;

    void Start()
    {
        CheckMaster();
    }
    public void SetMasterVolume(float level)
    {
        level = -80 + (.8f * level);
        audioMixer.SetFloat("MasterVolume", level);
        PlayerPrefs.SetFloat("masterVolume", masterSoundSlider.value);
    }
    public void SetMusicVolume(float level)
    {
        level = -80 + (.8f * level);
        audioMixer.SetFloat("MusicVolume", level);
        PlayerPrefs.SetFloat("musicVolume", musicSoundSlider.value);
    }
    public void SetEffectsVolume(float level)
    {
        level = -80 + (.8f * level);
        audioMixer.SetFloat("SoundFXVolume", level);
        PlayerPrefs.SetFloat("effectsVolume", effectsSoundSlider.value);
    }
    public void MasterVolumeOnOff()
    {
        if (masterValue == 1)
        {
            SetMasterVolume(0);
            masterValue = 0;
        }
        else
        {
            SetMasterVolume(PlayerPrefs.GetFloat("masterVolume"));
            masterValue = 1;
        }
        PlayerPrefs.SetInt("masterOnOff", masterValue);
        SetMasterBarrier();
    }
    public void MusicVolumeOnOff()
    {
        if (musicValue == 1)
        {
            SetMusicVolume(0);
            musicValue = 0;
        }
        else
        {
            SetMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
            musicValue = 1;
        }
        PlayerPrefs.SetInt("musicOnOff", musicValue);
        SetMusicBarrier();
    }
    public void EffectsVolumeOnOff()
    {
        if (effectsValue == 1)
        {
            SetEffectsVolume(0);
            effectsValue = 0;
        }
        else
        {
            SetEffectsVolume(PlayerPrefs.GetFloat("effectsVolume"));
            effectsValue = 1;
        }
        PlayerPrefs.SetInt("effectsOnOff", effectsValue);
        SetEffectsBarrier();
    }
    public void CheckMasterVolumeOn(int level)
    {
        if (level == 0)
        {
            SetMasterVolume(0);
        }
    }
    public void CheckMusicVolumeOn(int level)
    {
        if (level == 0)
        {
            SetMusicVolume(0);
        }
    }
    public void CheckEffectsVolumeOn(int level)
    {
        if (level == 0)
        {
            SetEffectsVolume(0);
        }
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
        optionMenu.SetActive(true);
        masterSoundSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSoundSlider.value = PlayerPrefs.GetFloat("musicVolume");
        effectsSoundSlider.value = PlayerPrefs.GetFloat("effectsVolume");
        masterValue = PlayerPrefs.GetInt("masterOnOff");
        CheckMasterVolumeOn(masterValue);
        musicValue = PlayerPrefs.GetInt("musicOnOff");
        CheckMusicVolumeOn(musicValue);
        effectsValue = PlayerPrefs.GetInt("effectsOnOff");
        CheckEffectsVolumeOn(effectsValue);
        SetMasterBarrier();
        SetMusicBarrier();
        SetEffectsBarrier();
        optionMenu.SetActive(false);
    }
}

//public void ChangeMasterVolume()
//{
//    PlayerPrefs.SetFloat("masterVolume", masterSoundSlider.value);
//    //SetAudioLevel(masterSoundSlider.value);
//    // call other script and change volume
//}
//public void ChangeMusicVolume()
//{
//    PlayerPrefs.SetFloat("musicVolume", musicSoundSlider.value);
//    //SetMusicLevel(musicSoundSlider.value);
//    // call other script and change volume
//}
//public void ChangeEffectsVolume()
//{
//    PlayerPrefs.SetFloat("effectsVolume", effectsSoundSlider.value);
//    //SetEffectsLevel(effectsSoundSlider.value);
//    // call other script and change volume
//}