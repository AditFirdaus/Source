using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroSceneManager : MonoBehaviour
{
    public static void ToMenu()
    {
        TransitionFade.LoadScene("Menu");
    }
}
