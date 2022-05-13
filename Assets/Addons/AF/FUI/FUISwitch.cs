using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUISwitch : MonoBehaviour
{
    public FWindowEvent currentWindow;

    public bool canSwitch = true;

    public void SwitchTo(FWindowEvent window)
    {
        if (!canSwitch) return;

        if (currentWindow == window) currentWindow.Close();

        if (currentWindow != null) currentWindow.Close();
        currentWindow = window;
        currentWindow.Open();
    }
}
