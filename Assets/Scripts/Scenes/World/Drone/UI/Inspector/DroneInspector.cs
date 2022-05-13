using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneInspector : MonoBehaviour
{
    public static bool isInspecting = false;
    public bool canInsepect;
    public KeyCode inspectKey = KeyCode.Space;
    public CanvasGroup canvasGroup;
    public AudioSource audioSource;

    public float targetPitch = 1;

    public float lerp = 0.1f;

    private void Update()
    {
        ManageInspect();
    }

    public void ManageInspect()
    {
        if (!canInsepect) return;

        isInspecting = Input.GetKey(inspectKey);
        float value = isInspecting ? 1 : 0;
        float volume = isInspecting ? 0.5f : 0;

        if (isInspecting)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (volume <= 0)
            {
                StopAudio();
            }
        }

        float newTimeScale = isInspecting ? 0.25f : 1;
        float newScale = isInspecting ? 1 : 1.1f;

        audioSource.volume = Mathf.MoveTowards(audioSource.volume, volume, Time.deltaTime);
        audioSource.pitch = Mathf.MoveTowards(audioSource.pitch, 1 + Random.Range(-0.25f, 0.25f), Time.deltaTime);

        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, value, lerp);
        if (isInspecting) TimeScale.slowMotion = true;
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * newScale, lerp);
    }

    public void StopAudio()
    {
        audioSource.Stop();
        audioSource.pitch = 0;
    }
}
