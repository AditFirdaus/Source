using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssemblyComponentCollections : MonoBehaviour
{
    public static UnityEvent<AssemblyComponent> OnSelect = new UnityEvent<AssemblyComponent>();
    public static AssemblyComponent selectedComponent;

    public GameObject UIAssemblyComponentPrefab;
    public Transform UIParent;
    public CanvasGroup flash;

    UIAssemblyComponent[] UIAssemblyComponents = new UIAssemblyComponent[0];

    private void Start()
    {
        AssemblyComponentGroup.OnSelect.AddListener(Display);
    }

    public void Display(ComponentGroup group)
    {
        if (!group) return;

        if (flash) flash.alpha = 1;

        // destroy all the existing UI components
        for (int i = 0; i < UIAssemblyComponents.Length; i++)
        {
            Destroy(UIAssemblyComponents[i].gameObject);
        }

        // create new UI components
        UIAssemblyComponents = new UIAssemblyComponent[group.components.Length];
        for (int i = 0; i < group.components.Length; i++)
        {
            var ui = Instantiate(UIAssemblyComponentPrefab, UIParent).GetComponent<UIAssemblyComponent>();
            ui.component = group.components[i];
            ui.Display(group.components[i]);

            UIAssemblyComponents[i] = ui;
        }

        UIAssemblyComponents[0].Select();
    }
}

