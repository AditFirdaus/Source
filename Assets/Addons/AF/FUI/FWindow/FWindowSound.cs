using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FWindowEvent))]
public class FWindowSound : MonoBehaviour
{
    public FWindowSounds sounds;

    FWindowEvent windowEvent;

    private void Start()
    {
        windowEvent = GetComponent<FWindowEvent>();

        Init();
    }

    public void Init()
    {
        windowEvent.events.onOpen.AddListener(() => Play(sounds.open));
        windowEvent.events.onClose.AddListener(() => Play(sounds.close));
    }

    public void Play(AudioClip clip)
    {
        if (clip) FSoundManager.PlayOneShot(clip);
    }

    [System.Serializable]
    public class FWindowSounds
    {
        public AudioClip open;
        public AudioClip close;
    }
}
