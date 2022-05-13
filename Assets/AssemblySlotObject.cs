using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssemblySlotObject : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool isHold = false;
    public RectTransform rectTransform;
    public float snapSize = 64;

    public Vector2Int gridSize;

    public float targetRotation;

    private void Update()
    {
        if (isHold)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                targetRotation -= 90;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                targetRotation += 90;
            }
        }

        rectTransform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetRotation), 0.25f);
    }

    public Vector2 Snap(Vector2 position)
    {
        return new Vector2(Mathf.Round(position.x / snapSize) * snapSize, Mathf.Round(position.y / snapSize) * snapSize);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHold = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHold = true;
    }
}
