using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMission : MonoBehaviour
{
    public static bool IsOpen { set; get; } = true;
    public CanvasLerp canvasLerp;
    public GameObject missionSectionPrefab;
    public Transform content;

    private void Start()
    {
        DisplayMission();
    }

    private void Update()
    {
        canvasLerp.alpha = IsOpen ? 1 : 0;
    }

    public void DisplayMission()
    {
        PlayerData.LoadData();
        Debug.Log(PlayerData.data.missionData.missions.Length);
        foreach (var mission in PlayerData.data.missionData.missions)
        {
            if (mission.isCompleted) continue;

            MissionSection missionSection = Instantiate(missionSectionPrefab, content).GetComponent<MissionSection>();
            missionSection.Display(mission);
        }
    }

    public void Toogle() => IsOpen = !IsOpen;
}
