using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorObject : MonoBehaviour
{
    public static float intensity = 0;
    public Renderer target;
    public float minDistance;
    public float distance;

    public RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        InspectorScreenShoot.OnScreenShoot.AddListener(SetMission);
        SetMission();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(target.transform.position, distance);
    }

    private void Update()
    {
        if (target.transform)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(target.transform.position, Camera.MonoOrStereoscopicEye.Mono);

            rectTransform.position = screenPos;
        }

        if (target.isVisible)
        {
            rectTransform.gameObject.SetActive(true);
        }
        else
        {
            rectTransform.gameObject.SetActive(true);
        }

        intensity = GetIntensity();
    }

    public float GetIntensity()
    {
        return GetDistanceIntensity();
    }

    public float GetDistanceIntensity()
    {
        Vector3 direction = DroneController.instance.drone.position - target.transform.position;

        if (direction.magnitude > distance)
        {
            return 0;
        }
        else
        {
            return 1 - ((direction.magnitude) / (distance + minDistance));
        }
    }

    public void SetMission()
    {
        PlayerData.LoadData();
        Mission mission = PlayerData.data.missionData.GetMission();

        if (mission != null)
        {
            ApplyMission(mission);
        }
        else
        {
            WorldSceneManager.ToOutro();
        }
    }

    public void ApplyMission(Mission mission)
    {
        target.transform.position = mission.missionInfo.position;
        target.transform.forward = mission.missionInfo.normal;
    }
}
