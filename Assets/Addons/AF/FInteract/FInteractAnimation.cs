using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FInteractEvent))]
public class FInteractAnimation : MonoBehaviour
{
    public Animator animator;
    public FInteractTrigger triggers;
    public FButtonAnimation animations;

    FInteractEvent interactEvent;

    private void Start()
    {
        interactEvent = GetComponent<FInteractEvent>();

        Init();
    }

    public void Init()
    {
        if (triggers.click) interactEvent.events.onClick.AddListener(() => animator.SetTrigger(animations.click));
        if (triggers.up) interactEvent.events.onUp.AddListener(() => animator.SetTrigger(animations.up));
        if (triggers.down) interactEvent.events.onDown.AddListener(() => animator.SetTrigger(animations.down));
        if (triggers.enter) interactEvent.events.onEnter.AddListener(() => animator.SetTrigger(animations.enter));
        if (triggers.exit) interactEvent.events.onExit.AddListener(() => animator.SetTrigger(animations.exit));
    }

    [System.Serializable]
    public class FButtonAnimation
    {
        public string click = "Click";
        public string up = "Up";
        public string down = "Down";
        public string enter = "Enter";
        public string exit = "Exit";
    }
}
