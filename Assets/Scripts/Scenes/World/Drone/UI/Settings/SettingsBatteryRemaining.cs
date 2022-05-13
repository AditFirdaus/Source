using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsBatteryRemaining : MonoBehaviour
{
    public TMP_Text remaining;
    public TMP_Text capacity;

    private void Update()
    {
        remaining.text = DroneBatteryComponent.power.ToString("00.00");
        capacity.text = DroneBatteryComponent.capacity.ToString("00.00");
    }
}
