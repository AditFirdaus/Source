using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float speed = 1;

    private void Start()
    {
        transform.Rotate(Vector3.right * Random.Range(-360, 360));
    }

    private void Update()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }
}
