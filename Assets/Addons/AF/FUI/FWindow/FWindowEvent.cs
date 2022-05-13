using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FWindowEvent : MonoBehaviour
{
    public bool isOpen = false;
    public RectTransform window;
    public FWindowEvents events;

    public void Toogle()
    {
        if (isOpen)
            Close();
        else
            Open();
    }

    public void Open()
    {
        isOpen = true;
        events.onOpen.Invoke();

        Debug.Log("Open");
    }

    public void Close()
    {
        isOpen = false;
        events.onClose.Invoke();

        Debug.Log("Close");
    }

    public void Show()
    {
        isOpen = true;
        events.onShow.Invoke();
    }

    public void Hide()
    {
        isOpen = false;
        events.onHide.Invoke();
    }

    [System.Serializable]
    public class FWindowEvents
    {
        public UnityEvent onOpen;
        public UnityEvent onClose;
        public UnityEvent onShow;
        public UnityEvent onHide;
    }
}
