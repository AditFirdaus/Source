using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionFade : TransitionScreen
{
    public static AsyncOperation async;

    // Update is called once per frame
    void Update()
    {
        IsLoading = async != null && !async.isDone;
        canvasLerp.alpha = IsLoading ? 1 : 0;
        if (async != null)
        {
            if (canvasLerp.canvasGroup.alpha == 1)
            {
                async.allowSceneActivation = true;
            }
            else
            {
                async.allowSceneActivation = false;
            }
        }
    }

    public static void LoadScene(string sceneName)
    {
        async = SceneManager.LoadSceneAsync(sceneName);
    }
}
