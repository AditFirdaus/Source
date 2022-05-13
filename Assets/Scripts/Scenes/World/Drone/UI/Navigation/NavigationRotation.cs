using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationRotation : MonoBehaviour
{
    DroneController droneController => DroneController.instance;
    public Vector3 droneEuler => droneController ? droneController.drone.eulerAngles : Vector3.zero;

    void Update()
    {
        if (droneController)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
