using UnityEngine;
using UnityEngine.Events;

public class DroneCameraComponent : DroneComponent
{
    public static float amount { set; get; } = 1;
    public static float power { set; get; } = 1;
    public static float usage { set; get; } = 1;
    public static float consumption => power * usage;
    public static float value => Mathf.Max(amount * usage, 100);

    float _amount, _usage, _consumption;

    void Update()
    {
        if (_amount != value) amountValue.Invoke(_amount = value);
        if (_usage != usage) usageValue.Invoke(_usage = usage);
        if (_consumption != consumption) consumptionValue.Invoke(_consumption = consumption);
    }
}
