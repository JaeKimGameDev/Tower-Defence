using UnityEngine;

public class SoundFxManager : MonoBehaviour
{
    public static SoundFxManager instance;
    [SerializeField] private AudioSource soundFXObject;

    //[SerializeField] private AudioMixerGroup musicMixerGroup;
    //[SerializeField] private AudioMixerGroup soundEffectsMixerGroup;
    //[SerializeField] private Sound sounds;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void PlaySounFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // spawn game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        // assign audioclip
        audioSource.clip = audioClip;
        // assign volume
        audioSource.volume = volume;
        //play sound
        audioSource.Play();
        //get length of audio clip
        float clipLength = audioSource.clip.length;
        //destroy clip after playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
