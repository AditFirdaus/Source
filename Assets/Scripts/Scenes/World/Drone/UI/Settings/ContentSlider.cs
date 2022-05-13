using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContentSlider : MonoBehaviour
{
    public string valueFormat;
    public string powerFormat;
    public string unit;
    public Image UIUsage;
    public TMP_Text UIPower;
    public TMP_Text UIValue;
    public TMP_Text UIUnit;
    public Image UIbackground;

    float _value;
    float _power;
    float _usage;

    public float value
    {
        set
        {
            if (UIValue && UIValue.text != value.ToString()) UIValue.text = (_value = Mathf.Lerp(_value, value, 0.25f)).ToString(valueFormat);
        }
    }

    public float power
    {
        set
        {
            if (UIPower && UIPower.text != valueFormat) UIPower.text = (_power = Mathf.Lerp(_power, value, 0.25f)).ToString(powerFormat);
        }
    }

    public float usage
    {
        set
        {
            if (UIUsage && UIUsage.fillAmount != value) UIUsage.fillAmount = (_usage = Mathf.Lerp(_usage, value, 0.25f));
        }
    }

    private void Update()
    {
        if (UIUnit.text != unit) UIUnit.text = unit;
        ManageBackground();
    }

    public void ManageBackground()
    {
        if (!UIbackground) return;
        if (!DroneSettings.isOpen) return;

        Vector2 size = UIbackground.rectTransform.sizeDelta;
        size.x = 164 + (UIValue.text.Length * (UIValue.fontSize / 2));

        UIbackground.rectTransform.sizeDelta = Vector2.Lerp(UIbackground.rectTransform.sizeDelta, size, 0.25f);
    }
}
