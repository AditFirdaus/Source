using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyDroneViewDrone : MonoBehaviour
{
    public CanvasGroup slots;

    private void Update()
    {
        ManageGrid();
    }

    public void ManageGrid()
    {
        float alpha = AssemblyDroneView.zoom ? 1 : 0.8f;

        slots.alpha = Mathf.Lerp(slots.alpha, alpha, 0.1f);
    }
}
