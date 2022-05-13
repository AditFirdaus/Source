using UnityEngine;
using UnityEngine.Events;

public class DroneBatteryComponent : MonoBehaviour
{
    public static bool IsDroneBatteryLow = false;
    public static bool useBattery { set; get; } = true;
    public static float capacity
    {
        set
        {
            _tempCapacity = Mathf.Max(value, 100);
        }
        get
        {
            return Mathf.Max(_tempCapacity, 100);
        }
    }
    public static float power { set; get; } = 0;
    public static float efficiency { set; get; } = 0;
    public static bool IsLow { get => power <= 0; }

    public static float efficiencyAmount => 1 - efficiency;
    public static float remainingPower => capacity - power;
    public static float remainingCapacity => (capacity != 0) ? power / capacity : 0;

    public Gradient batteryGradient = new Gradient();

    public static float _tempCapacity;

    public static float GetUsage()
    {
        if (!useBattery) return 0;

        float usage = 0;

        usage += DronePropellerComponent.usage;
        usage += DroneLightsComponent.usage;
        usage += DroneSensorComponent.usage;
        usage += DroneCameraComponent.usage;
        usage += DroneProcessorComponent.usage;

        usage /= 5;

        return usage * efficiencyAmount;
    }

    public static float GetConsumption()
    {
        if (!useBattery) return 0;

        float consumption = 0;

        consumption += DronePropellerComponent.consumption;
        consumption += DroneLightsComponent.consumption;
        consumption += DroneSensorComponent.consumption;
        consumption += DroneCameraComponent.consumption;
        consumption += DroneProcessorComponent.consumption;

        return consumption * efficiencyAmount;
    }

    public static void Recharge() => power = capacity;

    public bool sendLowCallback = true;
    public UnityEvent<float> usageValue;
    public UnityEvent<float> consumptionValue;
    public UnityEvent<float> capacityValue;
    public UnityEvent<float> remainingPowerValue;
    public UnityEvent<float> remainingCapacityValue;
    public UnityEvent<Color> batteryColor;
    public UnityEvent isLowEvent;

    float _capacity, _remainingPower, _remainingCapacity, _usage, _consumption;
    Color _color;

    void Update()
    {
        float newUsage = GetUsage();
        float newConsumption = GetConsumption();
        Color newColor = batteryGradient.Evaluate(remainingCapacity);

        if (_capacity != capacity) capacityValue.Invoke(_capacity = capacity);
        if (_remainingPower != remainingPower) remainingPowerValue.Invoke(Mathf.Max(_remainingPower = remainingPower, 0));
        if (_remainingCapacity != remainingCapacity) remainingCapacityValue.Invoke(_remainingCapacity = remainingCapacity);
        if (_usage != newUsage) usageValue.Invoke(_usage = newUsage);
        if (_consumption != newConsumption) consumptionValue.Invoke(_consumption = newConsumption);
        if (_color != newColor) batteryColor.Invoke(_color = newColor);

        if (IsLow && !IsDroneBatteryLow && sendLowCallback)
        {
            IsDroneBatteryLow = true;

            isLowEvent.Invoke();
            WorldSceneManager.ToBase();
        }
    }
}
