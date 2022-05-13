using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEngine : MonoBehaviour
{
    [Header("Drone Engine")]
    public bool lookup = true;
    public float thrustValue;
    public AnimationCurve thrustCurve;
    public float thrust => thrustCurve.Evaluate(thrustValue);
}
