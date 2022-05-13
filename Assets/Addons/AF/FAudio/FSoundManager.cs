using UnityEngine;
using UnityEngine.Audio;

public class FSoundManager : MonoBehaviour
{
    public static FSoundManager instance;
    public AudioMixerGroup mixerGroup;
    AudioSource audioSource;

    public AudioMixer audioMixer => mixerGroup.audioMixer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckAudioSource()
    {
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = mixerGroup;
        }
    }

    public static void PlayOneShot(AudioClip clip, float volume = 1)
    {
        if (!instance) CreateManager();

        instance.CheckAudioSource();

        instance.audioSource.PlayOneShot(clip, volume);
    }

    public static void CreateManager()
    {
        GameObject obj = new GameObject("FSoundManager");
        FSoundManager fSoundManager = obj.AddComponent<FSoundManager>();
        AudioSource audioSource = obj.AddComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = fSoundManager.mixerGroup;

        fSoundManager.audioSource = audioSource;

        GameObject.Instantiate(obj);
    }
}
