using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLights : MonoBehaviour
{
    public Light[] lights;
    public float intensity = 1;
    public float value => DroneLightsComponent.value;

    private void Update()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = value / 2;
            lights[i].range = value;
        }
    }
}
