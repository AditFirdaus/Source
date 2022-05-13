using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComponentSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AssemblyComponent component;
    public Image componentImage;
    public Image slotImage;
    public Color slotNormal;
    public Color slotHighlighted;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            AssemblyPreview preview = eventData.pointerDrag.GetComponent<AssemblyPreview>();
            if (preview)
            {
                component = AssemblyComponentCollections.selectedComponent;

                if (AssemblyDroneSlots.instance)
                {
                    AssemblyDroneSlots.instance.Save();
                }
            }
        }
    }

    private void Update()
    {
        if (component)
        {
            componentImage.gameObject.SetActive(true);
            componentImage.sprite = component.sprite;
        }
        else
        {
            componentImage.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        slotImage.color = slotNormal;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slotImage.color = slotHighlighted;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slotImage.color = slotNormal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        component = null;

        if (AssemblyDroneSlots.instance)
        {
            AssemblyDroneSlots.instance.Save();
        }
    }
}
