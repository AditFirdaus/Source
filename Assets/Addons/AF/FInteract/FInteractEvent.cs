using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FInteractEvent : UIBehaviour,
                            IPointerClickHandler,
                            IPointerDownHandler,
                            IPointerUpHandler,
                            IPointerEnterHandler,
                            IPointerExitHandler
{
    public bool interactable = true;
    public FInteractTrigger triggers;
    public FButtonEvents events;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (triggers.click) events.onClick.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (triggers.up) events.onUp.Invoke();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (triggers.down) events.onDown.Invoke();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (triggers.enter) events.onEnter.Invoke();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (triggers.exit) events.onExit.Invoke();
    }

    [System.Serializable]
    public class FButtonEvents
    {
        public UnityEvent onClick;
        public UnityEvent onUp;
        public UnityEvent onDown;
        public UnityEvent onEnter;
        public UnityEvent onExit;
    }
}
