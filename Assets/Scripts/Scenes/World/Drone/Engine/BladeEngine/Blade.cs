using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float lerp = 0.1f;
    public float spinTorque = 1;

    [Header("Sprites")]
    public SpriteRenderer bladeIdle;
    public SpriteRenderer bladeSpin;

    [Header("Alpha Curves")]
    public AnimationCurve bladeIdleCurve;
    public AnimationCurve bladeSpinCurve;

    public float torque;

    public void SetTorque(float t) => torque = Mathf.Lerp(torque, t, lerp);

    private void Update()
    {
        ManageRotation();
        ManageBladeIdle();
        ManageBladeSpin();
    }

    public void ManageRotation()
    {
        transform.Rotate(Vector3.up, torque * Time.deltaTime);
    }

    public void ManageBladeIdle()
    {
        if (!bladeIdle) return;

        float a = bladeIdleCurve.Evaluate(torque / spinTorque);
        bladeIdle.color = new Color(1, 1, 1, a);
    }

    public void ManageBladeSpin()
    {
        if (!bladeSpin) return;

        float a = bladeSpinCurve.Evaluate(torque / spinTorque);
        bladeSpin.color = new Color(1, 1, 1, a);
    }
}
