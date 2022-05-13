using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeEngine : DroneEngine
{
    [Header("Blade Engine")]
    public float maxTorque;
    public Blade blade;
    public AudioSource bladeSound;
    public float maxPitch = 1;

    void Update()
    {
        ManageBlade();
        ManageRotation();
        ManageBladeSound();
    }

    public void ManageBlade()
    {
        blade.SetTorque(thrust * maxTorque);
    }

    public void ManageBladeSound()
    {
        float curveThrust = thrustCurve.Evaluate(thrustValue) * Time.timeScale;
        bladeSound.volume = curveThrust;
        bladeSound.pitch = curveThrust * maxPitch + (DroneController.GetVelocity().magnitude * 0.25f);
    }

    public void ManageRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}
