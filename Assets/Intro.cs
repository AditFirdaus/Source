using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{

    public MissionData missionData;

    void Start()
    {
        FPlaylistPlayer.Dispose();
        FMusicManager.Dispose();

        PlayerData.LoadData();
        PlayerData.data.isFirstTime = false;
        PlayerData.data.isCompleted = false;
        PlayerData.data.missionData = missionData;
        PlayerData.SaveData();
    }
}
