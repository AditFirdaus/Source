using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyDroneGridPreview : MonoBehaviour
{
    public static Vector2 global;

    public RectTransform grid;
    public RectTransform preview;

    private void Update()
    {
        preview.position = global;
    }
}
