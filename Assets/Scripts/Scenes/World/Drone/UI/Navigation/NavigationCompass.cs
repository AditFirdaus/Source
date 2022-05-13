using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NavigationCompass : MonoBehaviour
{
    DroneController droneController => DroneController.instance;
    public RawImage compassLine;
    public TMP_Text compassAngleText;

    public float compassLineScale = 25;

    public float angle => droneController ? droneController.drone.eulerAngles.y : 0;

    private void Update()
    {
        if (droneController)
        {
            compassAngleText.text = $"-{angle.ToString("000.000")}-";
            compassLine.uvRect = new Rect(angle, 0, compassLineScale, 1);
        }
    }

}
