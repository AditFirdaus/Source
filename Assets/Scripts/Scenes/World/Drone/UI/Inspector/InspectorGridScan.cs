using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InspectorGridScan : MonoBehaviour
{
    public RectTransform grid;
    public RawImage gridScan;
    public float gridScanSpeed;
    public UnityEvent OnScanComplete;

    public static float gridScanTime;

    private void LateUpdate()
    {
        ManageGridScan();
    }

    public void ManageGridScan()
    {
        if (gridScan)
        {
            if (DroneInspector.isInspecting)
            {
                gridScan.uvRect = new Rect(gridScanTime, 0, 1, 1);
                gridScanTime += gridScanSpeed * Time.deltaTime * DroneCameraComponent.value;

                if (gridScanTime > 1)
                {
                    gridScanTime %= 1;
                    OnScanComplete.Invoke();
                }
            }
            else
            {
                gridScanTime = 0;
            }

            grid.localScale = Vector3.Lerp(Vector3.one * 1.25f, Vector3.one, gridScanTime / 1f);
        }
    }
}
