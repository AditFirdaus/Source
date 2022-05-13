using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyDroneView : MonoBehaviour
{
    public static float speed { set; get; } = 1;
    public static bool zoom => AssemblyPreview.selected;

    public RectTransform drone;

    private void Update()
    {
        float newSpeed = zoom ? 0.25f : 1;
        float newZoom = zoom ? 0.8f : 0.75f;
        speed = Mathf.Lerp(speed, newSpeed, 0.1f);
        drone.localScale = Vector3.Lerp(drone.localScale, Vector3.one * newZoom, 0.1f);
    }
}
