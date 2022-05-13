using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineController : MonoBehaviour
{
    [Range(0, 1)] public float thrust;
    public DroneEngine[] engines;

    private void Update()
    {
        for (int i = 0; i < engines.Length; i++)
        {
            engines[i].thrustValue = thrust;
        }
    }
}
