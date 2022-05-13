using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsUsage : MonoBehaviour
{
    public Gradient gradient;

    public TMP_Text usageText;
    public Image barLeft;
    public Image barRight;

    float usage => DroneBatteryComponent.GetUsage();

    float _usage;

    public string GetTextEstimate(float estimate = 0)
    {
        string text = "";

        switch (estimate)
        {
            case <= 0.25f:
                text = "NONE";
                break;
            case <= 0.50f:
                text = "LOW";
                break;
            case <= 0.75f:
                text = "MEDIUM";
                break;
            case <= 1.00f:
                text = "HIGH";
                break;
        }

        return text;
    }

    private void Update()
    {
        _usage = Mathf.Lerp(_usage, usage, 0.25f);

        if (usageText)
        {
            usageText.color = gradient.Evaluate(_usage);
            usageText.text = GetTextEstimate(_usage);
        }
        if (barLeft)
        {
            barLeft.color = gradient.Evaluate(_usage);
            barLeft.fillAmount = _usage;
        }
        if (barRight)
        {
            barRight.color = gradient.Evaluate(_usage);
            barRight.fillAmount = _usage;
        }
    }
}
