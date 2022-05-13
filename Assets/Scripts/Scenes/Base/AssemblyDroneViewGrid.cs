using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblyDroneViewGrid : MonoBehaviour
{
    public RawImage grid;

    float time;

    private void Update()
    {
        time += AssemblyDroneView.speed * Time.deltaTime;
        time = Mathf.Repeat(time, 1);

        grid.uvRect = new Rect(0, time, 1, 1);
    }
}
