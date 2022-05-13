using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssemblyPreview : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    public static bool selected;
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    public RectTransform sprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        selected = true;
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selected = false;
        sprite.anchoredPosition = Vector2.zero;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        sprite.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    private void Update()
    {
        float newScale = selected ? 0.9f : 1f;

        sprite.localScale = Vector3.Lerp(sprite.localScale, Vector3.one * newScale, 0.25f);
    }
}
