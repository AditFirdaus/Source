using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DroneComponentManager : MonoBehaviour
{
    public UnityEvent onBatteryLow;

    private void Start()
    {
        DroneBatteryComponent.Recharge();
    }

    private void Update()
    {
        ManageBattery();
    }

    public void ManageBattery()
    {
        DroneBatteryComponent.power -= DroneBatteryComponent.GetConsumption() * Time.deltaTime;
        if (DroneBatteryComponent.IsLow)
        {
            onBatteryLow.Invoke();
        }
    }
}
