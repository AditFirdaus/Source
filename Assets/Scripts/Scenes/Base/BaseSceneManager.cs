using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSceneManager : MonoBehaviour
{

    private void Start()
    {

    }

    public static void ToMenu()
    {
        TransitionFade.LoadScene("Menu");
    }

    public static void ToWorld()
    {
        TransitionFade.LoadScene("World");
    }
}
