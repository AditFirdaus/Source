using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneManager : MonoBehaviour
{
    public static void Exit()
    {
        Application.Quit();
    }

    public static void ToIntro()
    {
        TransitionFade.LoadScene("Intro");
    }

    public static void ToBase()
    {
        TransitionFade.LoadScene("Base");
    }
}
