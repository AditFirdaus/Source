using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSceneManager : MonoBehaviour
{
    public static void ToBase()
    {
        TransitionDrone.LoadScene("Base");
    }

    public static void ToOutro()
    {
        TransitionDrone.LoadScene("Outro");
    }
}
