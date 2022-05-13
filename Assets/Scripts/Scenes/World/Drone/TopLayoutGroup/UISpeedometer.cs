using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISpeedometer : MonoBehaviour
{
    DroneController droneController => DroneController.instance;
    public TMP_Text speedometerText;

    private void LateUpdate()
    {
        if (droneController)
        {
            speedometerText.text = $"{droneController.rb.velocity.magnitude.ToString("0.00")}m/s";
        }
    }
}
