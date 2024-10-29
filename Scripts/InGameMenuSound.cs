using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class InGameMenuSound : MonoBehaviour
{
    [SerializeField] private Slider masterSoundSlider;
    [SerializeField] private Slider musicSoundSlider;
    [SerializeField] private Slider effectsSoundSlider;
    [SerializeField] private AudioMixer audioMixer;
    private int masterValue, musicValue, effectsValue;
    public TextMeshProUGUI masterText, musicText, effectsText;

    public GameObject soundMenu;

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
        audioMixer.SetFloat("EffectsVolume", level);
        PlayerPrefs.SetFloat("effectsVolume", effectsSoundSlider.value);
    }
    public void MasterVolumeOnOff()
    {
        masterValue = PlayerPrefs.GetInt("masterOnOff");

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
        CheckMasterVolumeOn(masterValue);
    }
    public void MusicVolumeOnOff()
    {
        musicValue = PlayerPrefs.GetInt("musicOnOff");
        
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
        CheckMusicVolumeOn(musicValue);
    }
    public void EffectsVolumeOnOff()
    {
        effectsValue = PlayerPrefs.GetInt("effectsOnOff");
        
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
        CheckEffectsVolumeOn(effectsValue);
    }
    public void CheckMasterVolumeOn(int level)
    {
        if (level == 0)
        {
            SetMasterVolume(0);
            masterText.GetComponent<TextMeshProUGUI>().color = new Color32(148, 6, 6, 150);
        }
        else
        {
            masterText.GetComponent<TextMeshProUGUI>().color = new Color32(80, 138, 255, 255);
        }
    }
    public void CheckMusicVolumeOn(int level)
    {
        if (level == 0)
        {
            SetMusicVolume(0);
            musicText.GetComponent<TextMeshProUGUI>().color = new Color32(148, 6, 6, 150);
        }
        else
        {
            musicText.GetComponent<TextMeshProUGUI>().color = new Color32(80, 138, 255, 255);
        }
    }
    public void CheckEffectsVolumeOn(int level)
    {
        if (level == 0)
        {
            SetEffectsVolume(0);
            effectsText.GetComponent<TextMeshProUGUI>().color = new Color32(148, 6, 6, 150);
        }
        else
        {
            effectsText.GetComponent<TextMeshProUGUI>().color = new Color32(80, 138, 255, 255);
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
        soundMenu.SetActive(true);
        masterSoundSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSoundSlider.value = PlayerPrefs.GetFloat("musicVolume");
        effectsSoundSlider.value = PlayerPrefs.GetFloat("effectsVolume");

        masterValue = PlayerPrefs.GetInt("masterOnOff");
        CheckMasterVolumeOn(masterValue);
        musicValue = PlayerPrefs.GetInt("musicOnOff");
        CheckMusicVolumeOn(musicValue);
        effectsValue = PlayerPrefs.GetInt("effectsOnOff");
        CheckEffectsVolumeOn(effectsValue);
        

        //SetMasterBarrier();
        //SetMusicBarrier();
        //SetEffectsBarrier();
        //optionMenu.SetActive(false);
        soundMenu.SetActive(false);
    }
}
