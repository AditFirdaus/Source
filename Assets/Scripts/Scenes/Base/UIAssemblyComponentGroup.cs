using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAssemblyComponentGroup : MonoBehaviour
{
    public Image groupIcon;
    public TextMeshProUGUI groupName;

    [System.NonSerialized] public ComponentGroup group;

    public void Display(ComponentGroup group)
    {
        this.group = group;
        groupIcon.sprite = group.sprite;
        groupName.text = group.name;
    }

    public void Select()
    {
        if (group)
        {
            AssemblyComponentGroup.selectedGroup = group;
            AssemblyComponentGroup.OnSelect.Invoke(group);
        }
    }
}
