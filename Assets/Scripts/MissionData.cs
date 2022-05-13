using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MissionData
{
    public Mission[] missions = new Mission[0];

    public static void Complete()
    {
        PlayerData.LoadData();
        Mission mission = PlayerData.data.missionData.GetMission();
        mission.completed++;
        PlayerData.SaveData();
    }

    public Mission GetMission()
    {
        foreach (var mission in missions)
        {
            if (!mission.isCompleted)
            {
                return mission;
            }
        }

        return null;
    }
}

[System.Serializable]
public class Mission
{
    public Sprite image;
    public string name;
    public int size = 1;
    public int completed = 0;

    public MissionInfo missionInfo;

    public bool isCompleted => completed >= size;
}

[System.Serializable]
public class MissionInfo
{
    public Vector3 position = Vector3.zero;
    public Vector3 normal = Vector3.zero;
}
