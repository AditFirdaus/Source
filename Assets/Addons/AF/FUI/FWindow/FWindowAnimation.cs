using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FWindowEvent))]
public class FWindowAnimation : MonoBehaviour
{
    public Animator animator;

    public FWindowAnimationTriggers triggers;
    public FWindowAnimations animations;

    FWindowEvent windowEvent;

    private void Start()
    {
        windowEvent = GetComponent<FWindowEvent>();

        Init();
    }

    public void Init()
    {
        windowEvent.events.onOpen.AddListener(() => Open());
        windowEvent.events.onClose.AddListener(() => Close());
    }

    void Open()
    {
        if (!triggers.open)
        {
            AnimationShow();
            return;
        }
        animator.SetTrigger(animations.open);
    }

    void Close()
    {
        if (!triggers.close)
        {
            AnimationHide();
            return;
        }
        animator.SetTrigger(animations.close);
    }

    public void AnimationShow()
    {
        windowEvent.Show();
    }

    public void AnimationHide()
    {
        windowEvent.Hide();
    }

    [System.Serializable]
    public class FWindowAnimationTriggers
    {
        public bool open;
        public bool close;
    }

    [System.Serializable]
    public class FWindowAnimations
    {
        public string open = "Open";
        public string close = "Close";
    }
}
