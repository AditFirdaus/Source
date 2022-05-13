using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public static PlayerData data;

    public bool isFirstTime = true;
    public bool isCompleted = false;
    public MissionData missionData = new MissionData();
    public SlotData[] slotDatas = new SlotData[0];

    public bool canContinue => !isFirstTime && !isCompleted;

    public static void SaveData()
    {
        data.Save("PlayerData.json");
    }

    public static void LoadData()
    {
        IO.Load("PlayerData.json", out data);
    }
}
