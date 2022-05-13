using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspectorEstimate : MonoBehaviour
{
    public Gradient gradient;

    public TMP_Text estimateText;
    public Image barLeft;
    public Image barRight;
    public AudioClip estimateSound;

    float estimate => InspectorObject.intensity * DroneSensorComponent.value;

    float time;

    public string GetTextEstimate(float estimate = 0)
    {
        string text = "";

        switch (estimate)
        {
            case <= 0.25f:
                text = "NONE";
                break;
            case <= 0.50f:
                text = "BAD";
                break;
            case <= 0.75f:
                text = "GOOD";
                break;
            case <= 1.00f:
                text = "GREAT";
                break;
        }

        return text;
    }

    private void Update()
    {
        if (estimateText)
        {
            estimateText.color = gradient.Evaluate(estimate);
            estimateText.text = GetTextEstimate(estimate);
        }
        if (barLeft)
        {
            barLeft.color = gradient.Evaluate(estimate);
            barLeft.fillAmount = estimate;
        }
        if (barRight)
        {
            barRight.color = gradient.Evaluate(estimate);
            barRight.fillAmount = estimate;
        }

        time += Time.deltaTime;
        if (time >= (1f - InspectorObject.intensity) * 5)
        {
            time = 0;
            FSoundManager.PlayOneShot(estimateSound, 0.05f);
        }
    }
}
