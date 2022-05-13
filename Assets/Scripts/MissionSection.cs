using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionSection : MonoBehaviour
{
    public Mission mission;

    public Image missionImage;
    public TMP_Text missionName;
    public TMP_Text sizeText;
    public TMP_Text completedText;

    public void Display(Mission mission)
    {
        this.mission = mission;
        missionImage.sprite = mission.image;
        missionName.text = mission.name;
        sizeText.text = mission.size.ToString();
        completedText.text = mission.completed.ToString();
    }
}
