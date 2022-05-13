using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssemblyDroneSlots : MonoBehaviour
{
    public static AssemblyDroneSlots instance;
    public ComponentSlot[] slots => transform.GetComponentsInChildren<ComponentSlot>(true);

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Load();
        AssemblyComponentCollections.OnSelect.AddListener((i) => Load());
    }

    public ComponentEffect GetEffects()
    {
        ComponentEffect effect = new ComponentEffect();
        // add all slot component effects

        foreach (var slot in slots)
        {
            if (slot.component) effect += slot.component.effect;
        }

        return effect;
    }

    [ContextMenu("Save")]
    public void Save()
    {
        ComponentSlot[] componentSlots = slots;

        PlayerData.data.slotDatas = new SlotData[componentSlots.Length];

        for (int i = 0; i < componentSlots.Length; i++)
        {
            PlayerData.data.slotDatas[i] = new SlotData();
            PlayerData.data.slotDatas[i].slot = componentSlots[i];
            PlayerData.data.slotDatas[i].component = componentSlots[i].component;
        }

        PlayerData.SaveData();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        PlayerData.LoadData();

        foreach (var slot in slots)
        {
            slot.component = null;
        }

        foreach (var slotData in PlayerData.data.slotDatas)
        {
            if (slotData.slot)
            {
                slotData.slot.component = slotData.component;
            }
        }
    }

    private void Update()
    {
        DroneComponent.SetEffect(GetEffects());
    }
}

[System.Serializable]
public class SlotData
{
    public ComponentSlot slot;
    public AssemblyComponent component;

    public SlotData()
    {
        slot = null;
        component = null;
    }
}
