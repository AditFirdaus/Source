using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUIKeySwitch : FUISwitch
{
    public UIKeySwitch[] uis;

    private void Update()
    {
        ManageSwitch();
    }

    void ManageSwitch()
    {
        if (!canSwitch) return;

        for (int i = 0; i < uis.Length; i++)
        {
            if (Input.GetKeyDown(uis[i].key))
            {
                SwitchTo(uis[i].Window);
            }
        }
    }

    [System.Serializable]
    public class UIKeySwitch
    {
        public KeyCode key;
        public FWindowEvent Window;
    }
}
