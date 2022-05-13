using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TransitionDrone : TransitionScreen
{
    public static AsyncOperation async;
    public bool batteryLowCallback = true;
    public Image distanceFill;
    public TMP_Text distanceText;

    public static float distance = 0;
    public static float currentDistance;

    // Update is called once per frame
    void Update()
    {
        IsLoading = async != null && !async.isDone;
        canvasLerp.alpha = IsLoading ? 1 : 0;

        if (async != null)
        {
            if ((currentDistance == 0) && canvasLerp.canvasGroup.alpha == 1)
            {
                async.allowSceneActivation = true;
            }
            else
            {
                async.allowSceneActivation = false;
            }
        }

        currentDistance = Mathf.MoveTowards(currentDistance, 0, Mathf.Max(DronePropellerComponent.amount, 2) * Time.deltaTime);

        distanceFill.fillAmount = currentDistance / distance;
        distanceText.text = currentDistance.ToString("00.00 M") + " | " + distance.ToString("0.00 M");
    }

    public static void LoadScene(string sceneName)
    {
        if (!DroneController.instance) return;

        TimeScale.slowMotion = false;

        distance = DroneController.instance.transform.position.magnitude / 4;
        currentDistance = distance;

        async = SceneManager.LoadSceneAsync(sceneName);
    }
}
