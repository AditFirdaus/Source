using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLerp : MonoBehaviour
{
    public static float snap = 0.001f;
    public bool active;
    public bool autoIntereactable;
    public CanvasGroup canvasGroup;
    public float alpha;
    public float lerp;

    public bool state => canvasGroup.alpha > 0.5f;

    private void Start()
    {
        canvasGroup.alpha = alpha;
    }

    private void Update()
    {
        if (!active) return;

        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, alpha, lerp);

        if (autoIntereactable)
        {
            canvasGroup.interactable = state;
            canvasGroup.blocksRaycasts = state;
        }

        if (Mathf.Abs(canvasGroup.alpha - 0) < snap) canvasGroup.alpha = 0;
        if (Mathf.Abs(canvasGroup.alpha - 1) < snap) canvasGroup.alpha = 1;
    }

}
