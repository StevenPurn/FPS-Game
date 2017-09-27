using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 curRotation = Vector3.zero;
    private float currentCamRotationX = 0f;
    private float camRotationX = 0f;

    [SerializeField]
    private float camRotationLimit = 85f;

    [SerializeField]
    private bool inverted;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 vel)
    {
        velocity = vel;
    }

    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    public void Rotate(Vector3 rot)
    {
        rotation = rot;
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            currentCamRotationX += camRotationX;
            currentCamRotationX = Mathf.Clamp(currentCamRotationX, -camRotationLimit, camRotationLimit);
            cam.transform.localEulerAngles = new Vector3(currentCamRotationX, 0f, 0f);
        }
    }

    public void RotateCamera(float rot)
    {
        camRotationX = inverted ? rot : -rot;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
}