using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIAssemblyComponent : MonoBehaviour
{
    public Image componentIcon;
    public TextMeshProUGUI componentName;

    [System.NonSerialized] public AssemblyComponent component;

    public void Display(AssemblyComponent component)
    {
        this.component = component;
        componentIcon.sprite = component.sprite;
        componentName.text = component.name;
    }

    public void Select()
    {
        if (component)
        {
            AssemblyComponentCollections.selectedComponent = component;
            AssemblyComponentCollections.OnSelect.Invoke(component);
        }
    }
}
