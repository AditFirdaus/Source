using UnityEngine;
using UnityEngine.Events;

public class DroneLightsComponent : DroneComponent
{
    public static float amount { set; get; } = 500;
    public static float power { set; get; } = 1;
    public static float usage { set; get; } = 1;
    public static float consumption => power * usage;
    public static float value => Mathf.Max(amount * usage, 8);

    void Update()
    {
        amountValue.Invoke(value);
        usageValue.Invoke(usage);
        consumptionValue.Invoke(consumption);
    }
}
