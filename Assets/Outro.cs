using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FPlaylistPlayer.Dispose();
        FMusicManager.Dispose();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
