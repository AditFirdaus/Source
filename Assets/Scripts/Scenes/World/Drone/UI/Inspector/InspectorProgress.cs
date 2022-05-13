using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspectorProgress : MonoBehaviour
{
    public TMP_Text progressText;
    public Image barLeft;
    public Image barRight;

    float progress => InspectorGridScan.gridScanTime / 1;

    private void Update()
    {
        if (progressText) progressText.text = (progress * 100).ToString("00.00");
        if (barLeft) barLeft.fillAmount = progress;
        if (barRight) barRight.fillAmount = progress;
    }
}
