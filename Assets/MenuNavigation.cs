using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public RectTransform buttonContinue;
    public RectTransform buttonNewGame;

    private void Start()
    {
        ManageContinueButton();
    }

    void ManageContinueButton()
    {
        PlayerData.LoadData();
        buttonContinue.gameObject.SetActive(false);
        if (PlayerData.data.canContinue)
        {
            buttonContinue.gameObject.SetActive(true);
        }
    }
}
