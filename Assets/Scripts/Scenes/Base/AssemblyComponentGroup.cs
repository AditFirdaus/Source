using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssemblyComponentGroup : MonoBehaviour
{
    public static UnityEvent<ComponentGroup> OnSelect = new UnityEvent<ComponentGroup>();
    public static ComponentGroup selectedGroup;

    public GameObject UIAssemblyComponentGroupPrefab;
    public Transform UIParent;
    public ComponentGroup[] groups;
    public CanvasGroup flash;

    UIAssemblyComponentGroup[] UIAssemblyComponentGroups = new UIAssemblyComponentGroup[0];

    private void Start()
    {
        Display();
    }

    public void Display()
    {
        if (flash) flash.alpha = 1;

        // destroy all the existing UI components
        for (int i = 0; i < UIAssemblyComponentGroups.Length; i++)
        {
            Destroy(UIAssemblyComponentGroups[i].gameObject);
        }

        // create new UI components
        UIAssemblyComponentGroups = new UIAssemblyComponentGroup[groups.Length];
        for (int i = 0; i < UIAssemblyComponentGroups.Length; i++)
        {
            var ui = Instantiate(UIAssemblyComponentGroupPrefab, UIParent).GetComponent<UIAssemblyComponentGroup>();
            ui.Display(groups[i]);

            UIAssemblyComponentGroups[i] = ui;
        }

        UIAssemblyComponentGroups[0].Select();
    }
}
