using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InspectorScreenShoot : MonoBehaviour
{
    public static InspectorScreenShoot instance;
    public static UnityEvent OnScreenShoot = new UnityEvent();

    public Animator animator;
    public AudioClip shutterClip;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ScreenShoot()
    {
        FSoundManager.PlayOneShot(shutterClip);
        animator.SetTrigger("ScreenShoot");

        if (InspectorObject.intensity >= 0.5f)
        {
            InspectorData.CreateUIData(5000 * InspectorObject.intensity * DroneSensorComponent.value);
            MissionData.Complete();
            OnScreenShoot.Invoke();
        }
    }
}
