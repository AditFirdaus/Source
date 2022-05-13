using UnityEngine;
using UnityEngine.Events;

public class DronePropellerComponent : DroneComponent
{
    public static float amount { set; get; } = 1000;
    public static float power { set; get; } = 1;
    public static float usage { set; get; } = 1;

    public static float consumption => power * usage;
    public static float value => Mathf.Max(amount * usage, 300);

    void Update()
    {
        amountValue.Invoke(value);
        usageValue.Invoke(usage);
        consumptionValue.Invoke(consumption);
    }
}
