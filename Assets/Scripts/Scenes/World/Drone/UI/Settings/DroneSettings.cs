using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSettings : MonoBehaviour
{
    public static bool isOpen;
    public bool canOpen;
    public KeyCode triggerKey = KeyCode.LeftShift;
    public CanvasGroup canvasGroup;

    public float lerp = 0.1f;

    private void Update()
    {
        if (canvasGroup.alpha <= 0.01f)
        {
            canvasGroup.gameObject.SetActive(false);
        }
        else
        {
            canvasGroup.gameObject.SetActive(true);
        }

        ManageSettings();
    }

    public void ManageSettings()
    {
        canvasGroup.interactable = isOpen;
        canvasGroup.blocksRaycasts = isOpen;

        if (!canOpen) return;
        if (Input.GetKeyDown(triggerKey)) isOpen = !isOpen;

        if (DroneInspector.isInspecting || DroneController.inControl) isOpen = false;

        float value = isOpen ? 1 : 0;
        float newScale = isOpen ? 1 : 1.25f;

        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, value, lerp);
        if (isOpen) TimeScale.slowMotion = true;
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * newScale, lerp);
    }
}
