using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public static float globalScale = 1;
    public static bool slowMotion = false;
    public float scale = 1;

    private void LateUpdate()
    {
        if (scale != globalScale)
        {
            scale = globalScale;
        }

        if (globalScale != scale)
        {
            globalScale = scale;
        }

        if (Time.timeScale != globalScale)
        {
            Time.timeScale = globalScale;
        }
        ManageSlowMotion();
    }

    public void ManageSlowMotion()
    {
        float value = slowMotion ? 0.25f : 1;
        TimeScale.globalScale = Mathf.Lerp(TimeScale.globalScale, value, 0.1f);
        slowMotion = false;
    }
}
