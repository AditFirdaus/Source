using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FMusicManager : MonoBehaviour
{
    public static bool playMusic = true;
    public static FMusicManager instance;
    public AudioMixerGroup mixerGroup;
    [Range(0, 1)] float lowpass = 1;
    [Range(0, 1)] float volume = 1;

    public AudioMixer audioMixer => mixerGroup.audioMixer;

    public float Lowpass
    {
        set => audioMixer.SetFloat("lowpass", (lowpass = value) * 5000);
        get
        {
            float rawValue = 0;
            audioMixer.GetFloat("lowpass", out rawValue);
            return lowpass = rawValue / 5000;
        }
    }

    public float Volume
    {
        set => audioMixer.SetFloat("volume", Mathf.Lerp(-80, 0, volume = value));
        get
        {
            float rawValue = 0;
            audioMixer.GetFloat("volume", out rawValue);
            return volume = Mathf.InverseLerp(-80, 0, rawValue);
        }
    }

    [System.NonSerialized]
    public AudioSource audioSource;

    LTDescr lowpassTween;
    LTDescr volumeTween;

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

    private void Update()
    {
        if (!audioSource) return;
        if (!playMusic)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
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

    public static void Play(AudioClip clip)
    {
        if (!instance) CreateManager();

        instance.CheckAudioSource();

        instance.audioSource.clip = clip;
        instance.audioSource.Play();
    }

    public static void Dispose()
    {
        if (instance)
        {
            Destroy(instance.gameObject);
        }
    }

    public static LTDescr LeanVolume(float value = 1, float time = 0.25f)
    {
        if (!instance) CreateManager();

        if (instance.volumeTween != null)
            LeanTween.cancel(instance.volumeTween.id);

        return instance.volumeTween = LeanTween.value(instance.Volume, value, time)
            .setOnUpdate((float value) =>
            {
                instance.Volume = value;
            });
    }

    public static LTDescr LeanLowpass(float value = 1, float time = 0.25f)
    {
        if (!instance) CreateManager();

        if (instance.lowpassTween != null)
            LeanTween.cancel(instance.lowpassTween.id);

        return instance.lowpassTween = LeanTween.value(instance.Lowpass, value, time)
            .setOnUpdate((float value) =>
            {
                instance.Lowpass = value;
            });
    }

    public static void CreateManager()
    {
        GameObject obj = new GameObject("FMusicManager");
        FMusicManager fMusicManager = obj.AddComponent<FMusicManager>();
        AudioSource audioSource = obj.AddComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = fMusicManager.mixerGroup;

        fMusicManager.audioSource = audioSource;

        GameObject.Instantiate(obj);
    }
}
