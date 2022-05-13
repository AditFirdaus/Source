using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DroneController : MonoBehaviour
{
    public static DroneController instance;
    public static bool isMoving = false;
    public static bool isRotating = false;
    public static bool inControl => isMoving || isRotating;

    public Transform drone;
    public float rotationSpeed;
    public static float speed => DronePropellerComponent.value;
    public float maxPitch = 15;

    [System.NonSerialized]
    public Rigidbody rb;

    float xRotation = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up;
    }

    private void FixedUpdate()
    {

    }

    void Update()
    {
        ManageMovement();
    }

    private void LateUpdate()
    {
        ManageRotation();
    }

    public void ManageMovement()
    {
        Vector3 deltaVelocity = PlayerInput.Drone.Movement.Get() * speed * Time.timeScale * Time.smoothDeltaTime;

        isMoving = (deltaVelocity.magnitude != 0);

        rb.AddForce(transform.TransformDirection(deltaVelocity));

        ManageBounds();
    }

    public void ManageBounds()
    {
        if (!(transform.position.magnitude >= 750)) return;

        rb.velocity *= -1;
        rb.position = Vector3.ClampMagnitude(rb.position, 750);
    }

    public void ManageRotation()
    {
        Vector2 rotation = PlayerInput.Drone.Rotation.Get();

        isRotating = (rotation.magnitude != 0);

        rb.AddRelativeTorque(transform.InverseTransformDirection(new Vector3(0, rotation.x, 0)) * rotationSpeed * Time.timeScale * Time.smoothDeltaTime);

        xRotation -= rotation.y / 2 * rotationSpeed * Time.timeScale * Time.smoothDeltaTime;
        xRotation = Mathf.Clamp(xRotation, -maxPitch, maxPitch);
        drone.localRotation = Quaternion.Slerp(drone.localRotation, Quaternion.Euler(new Vector3(xRotation, 0, 0) + transform.InverseTransformDirection(new Vector3(rb.velocity.z, 0, -rb.velocity.x)) * 2.5f), 0.1f * Time.timeScale);
    }

    public static Vector3 GetVelocity()
    {
        if (instance && instance.rb)
            return instance.rb.velocity;
        else
            return Vector3.zero;
    }
}
