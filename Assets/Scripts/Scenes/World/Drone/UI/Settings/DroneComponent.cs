using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DroneComponent : MonoBehaviour
{
    public UnityEvent<float> amountValue;
    public UnityEvent<float> usageValue;
    public UnityEvent<float> consumptionValue;

    public static void SetEffect(ComponentEffect effect)
    {
        DroneBatteryComponent.capacity = effect.battery.amount;
        DronePropellerComponent.amount = effect.propeller.amount;
        DroneLightsComponent.amount = effect.lights.amount;
        DroneSensorComponent.amount = effect.sensor.amount;
        DroneCameraComponent.amount = effect.camera.amount;
        DroneProcessorComponent.amount = effect.processor.amount;
    }
}
