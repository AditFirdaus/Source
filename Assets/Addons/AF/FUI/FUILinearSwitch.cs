using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUILinearSwitch : FUISwitch
{
    public FWindowEvent[] windows;
    int index = 0;

    public void SwitchToOffset(int offset = 0)
    {
        index += offset;

        if (index < 0) index = windows.Length - 1;
        if (index >= windows.Length) index = 0;

        SwitchToIndex(index);
    }

    public void SwitchToIndex(int index)
    {
        bool outOfRange = index < 0 || index >= windows.Length;
        if (outOfRange) return;

        SwitchTo(windows[index]);
    }

    public void Previus() => SwitchToOffset(-1);
    public void Next() => SwitchToOffset(1);
}
