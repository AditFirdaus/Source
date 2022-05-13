using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneNavigationBattery : MonoBehaviour
{
    public RectTransform lowIndicator;
    public RectTransform chargeIndicator;
    public AudioClip lowBatterySound;

    float time;

    private void Update()
    {
        float remaining = DroneBatteryComponent.remainingCapacity;
        bool low = DroneBatteryComponent.power < DroneBatteryComponent.capacity * 0.25f;

        lowIndicator.gameObject.SetActive(low);

        if (low)
        {
            time += Time.deltaTime;

            if (time > Mathf.Max((5 * remaining), 0.25f))
            {
                FSoundManager.PlayOneShot(lowBatterySound, 0.25f);
                time = 0;
            }

            chargeIndicator.gameObject.SetActive(DroneController.instance.transform.position.magnitude <= 10);
        }
        else
        {
            chargeIndicator.gameObject.SetActive(false);
            DroneBatteryComponent.IsDroneBatteryLow = false;
        }
    }

    public static void Recharge()
    {
        DroneBatteryComponent.Recharge();
    }
}
