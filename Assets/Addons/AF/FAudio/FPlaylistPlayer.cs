using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FPlaylistPlayer : MonoBehaviour
{
    public static FPlaylistPlayer instance;

    public bool autoplay = true;
    public AudioClip[] clips;
    public UnityEvent onPlaylistEnd;

    float time;

    AudioSource audioSource => FMusicManager.instance.audioSource;

    private void Awake()
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

    private void Start()
    {
        if (autoplay) PlayRandom();
    }

    private void Update()
    {
        ManageAudioSource();
    }

    public void ManageAudioSource()
    {
        if (!FMusicManager.instance) return;
        if (!audioSource) return;

        if (audioSource.isPlaying)
        {
            if (audioSource.time >= audioSource.clip.length)
            {
                audioSource.Stop();
                onPlaylistEnd.Invoke();
            }
        }
    }

    public static void Dispose()
    {
        if (instance)
        {
            Destroy(instance.gameObject);
        }
    }

    [ContextMenu("Play Random")]
    public void PlayRandom()
    {
        int index = Random.Range(0, clips.Length);
        Play(clips[index]);
    }

    public void Play(AudioClip clip)
    {
        time = audioSource ? audioSource.time : 0;
        FMusicManager.LeanVolume(0, 3).setOnComplete(() =>
        {
            FMusicManager.Play(clip);

            audioSource.time = Mathf.Repeat(time, clip.length);

            FMusicManager.LeanVolume(1, 3);
        });
    }
}
