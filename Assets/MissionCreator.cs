using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCreator : MonoBehaviour
{
    public Transform target;
    public float mapRadius = 1;
    public float missionInfoLength = 1;
    public MissionData missionData;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < missionData.missions.Length; i++)
        {
            MissionInfo missionInfo = missionData.missions[i].missionInfo;
            Gizmos.DrawRay(missionInfo.position, missionInfo.normal * missionInfoLength);
        }
    }

    [ContextMenu("RandomizeMissionName")]
    public void RandomizeMissionName()
    {
        for (int i = 0; i < missionData.missions.Length; i++)
        {
            missionData.missions[i].name = UIData.RandomString(10);
        }
    }

    [ContextMenu("RandomizeMissionSize")]
    public void RandomizeMissionSize()
    {
        for (int i = 0; i < missionData.missions.Length; i++)
        {
            missionData.missions[i].size = Random.Range(1, 5);
        }
    }

    [ContextMenu("RandomizeMissionPosition")]
    public void RandomizeMissionInfo()
    {
        for (int i = 0; i < missionData.missions.Length; i++)
        {
            missionData.missions[i].missionInfo = GetRandomMissionInfo();
        }
    }


    public IEnumerator TakeScreenShootEnumerator()
    {
        for (int i = 0; i < missionData.missions.Length; i++)
        {
            Mission mission = missionData.missions[i];
            MissionInfo missionInfo = mission.missionInfo;

            target.position = missionInfo.position;
            target.forward = missionInfo.normal;

            yield return StartCoroutine(ScreenShootCamera.TakeScreenShoot(mission.name));
        }
    }

    [ContextMenu("TakeScreenShoot")]
    public void TakeScreenShoot()
    {
        StartCoroutine(TakeScreenShootEnumerator());
    }

    [ContextMenu("UpdateScreenShoot")]
    public void UpdateScreenShoot()
    {
        for (int i = 0; i < missionData.missions.Length; i++)
        {
            Mission mission = missionData.missions[i];

            mission.image = ScreenShootCamera.GetScreenShoot(mission.name);
        }
    }

    public MissionInfo GetRandomMissionInfo()
    {
        MissionInfo missionInfo = new MissionInfo();

        // Get the random x, z position inside the map
        // Shoot a raycast from the top position to the bottom of the map
        // If the raycast hits the ground, get the position and normal of the hit. If not then repeat

        Vector2 circle = Random.insideUnitCircle * mapRadius;
        Vector3 position = new Vector3(circle.x, 1000, circle.y);

        RaycastHit hit;
        Ray ray = new Ray(position, Vector3.down);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            missionInfo.position = hit.point;
            missionInfo.normal = hit.normal;
        }
        return missionInfo;
    }
}
