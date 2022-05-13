using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyDroneBlades : MonoBehaviour
{
    public static float speed { set; get; } = 2;
    public static float angle { set; get; } = 0;

    float time;

    private void Update()
    {
        time += speed * AssemblyDroneView.speed * Time.deltaTime;
        time = Mathf.Repeat(time, 1);
        angle = time * 360;
    }
}
