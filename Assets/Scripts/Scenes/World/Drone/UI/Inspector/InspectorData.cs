using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorData : MonoBehaviour
{
    public static InspectorData instance;
    public static int capacity = 5;
    public static List<UIData> data = new List<UIData>();

    public Transform parentContainer;
    public GameObject uiDataQueuePrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Process();
    }

    public static void CreateUIData(float dataSize = 0)
    {
        if (!instance) return;

        if (data.Count < capacity)
        {
            var uiData = Instantiate(instance.uiDataQueuePrefab, instance.parentContainer).GetComponent<UIData>();
            uiData.dataSize = dataSize;
        }
    }

    public static void Process()
    {
        if (!instance) return;

        float amount = DroneProcessorComponent.value / data.Count;

        for (int i = 0; i < data.Count; i++)
        {
            data[i]?.Process(amount);
        }
    }
}
