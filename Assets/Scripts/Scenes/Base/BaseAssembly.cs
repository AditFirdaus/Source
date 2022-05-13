using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAssembly : MonoBehaviour
{
    public static bool IsOpen { set; get; } = false;
    public CanvasLerp canvasLerp;

    private void Update()
    {
        canvasLerp.alpha = IsOpen ? 1 : 0;
    }

    public void Toogle() => IsOpen = !IsOpen;
}
