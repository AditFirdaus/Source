using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FInteractEvent))]
public class FInteractSound : MonoBehaviour
{
    public FInteractTrigger triggers;
    public FButtonSounds sounds;

    FInteractEvent interactEvent;

    private void Start()
    {
        interactEvent = GetComponent<FInteractEvent>();

        Init();
    }

    public void Init()
    {
        if (triggers.click) interactEvent.events.onClick.AddListener(() => Play(sounds.click));
        if (triggers.up) interactEvent.events.onUp.AddListener(() => Play(sounds.up));
        if (triggers.down) interactEvent.events.onDown.AddListener(() => Play(sounds.down));
        if (triggers.enter) interactEvent.events.onEnter.AddListener(() => Play(sounds.enter));
        if (triggers.exit) interactEvent.events.onExit.AddListener(() => Play(sounds.exit));
    }

    public void Play(AudioClip clip)
    {
        if (clip) FSoundManager.PlayOneShot(clip);
    }

    [System.Serializable]
    public class FButtonSounds
    {
        public AudioClip click;
        public AudioClip up;
        public AudioClip down;
        public AudioClip enter;
        public AudioClip exit;
    }
}
