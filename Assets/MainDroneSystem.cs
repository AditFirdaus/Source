using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MainDroneSystem : MonoBehaviour
{
    public TMP_Text uiBattery;
    public TMP_Text uiCamera;
    public TMP_Text uiLights;
    public TMP_Text uiProcessor;
    public TMP_Text uiPropeller;
    public TMP_Text uiSensor;

    private void Update()
    {
        uiBattery.text = DroneBatteryComponent.capacity.ToString();
        uiCamera.text = DroneCameraComponent.amount.ToString();
        uiLights.text = DroneLightsComponent.amount.ToString();
        uiProcessor.text = DroneProcessorComponent.amount.ToString();
        uiPropeller.text = DronePropellerComponent.amount.ToString();
        uiSensor.text = DroneSensorComponent.amount.ToString();
    }
}
