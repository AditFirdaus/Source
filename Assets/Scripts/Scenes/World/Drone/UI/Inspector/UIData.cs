using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIData : MonoBehaviour
{
    public float dataSize = 100;

    public string dataName = "";
    public TMP_Text dataText;
    public Image dataProgress;

    float data;

    private void Start()
    {
        dataName = RandomString(10);

        data = dataSize;
        UpdateUI();
        Add();
    }

    public void Process(float amount)
    {
        data -= amount;
        UpdateUI();

        if (data <= 0)
        {
            Remove();
            Destroy(gameObject);
        }
    }

    public void UpdateUI()
    {
        dataText.text = $"{(int)data}KB | {dataName}";
        dataProgress.fillAmount = data / dataSize;
    }

    public static string RandomString(int length)
    {
        System.Random random = new System.Random();

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public void Add()
    {
        InspectorData.data.Add(this);
    }

    public void Remove()
    {
        InspectorData.data.Remove(this);
    }

}
