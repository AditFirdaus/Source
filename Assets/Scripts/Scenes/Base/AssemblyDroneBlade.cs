using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyDroneBlade : MonoBehaviour
{
    public Transform blade;

    private void Update()
    {
        blade.localEulerAngles = new Vector3(0, 0, AssemblyDroneBlades.angle);
    }
}
