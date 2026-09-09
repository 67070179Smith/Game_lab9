using UnityEngine;
public class CarController : MonoBehaviour
{
    [Header("Customizable Parameters")]
    public float maxSpeed = 20f;
    public float acceleration = 10f;
    public float turnSpeed = 50f;
    public float braking = 15f;
    public float grip = 1f;
    [Header("Center of Mass")]
    public Vector3 centerOfMassOffset = new Vector3(0f, -0.5f, 0f);
    private Rigidbody rb;
    private float throttleInput;
    private float steerInput;
    private bool isBraking;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            enabled = false;
            return;
        }
        rb.centerOfMass = centerOfMassOffset;
    }
    void Update()
    {
        throttleInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
        isBraking = Input.GetKey(KeyCode.Space);
    }
    void FixedUpdate()
    {
        if (rb == null) return;
        HandleDrive();
        HandleSteer();
        HandleGrip();
    }
    void HandleDrive()
    {
        float currentSpeed = Vector3.Dot(rb.linearVelocity,
        transform.forward);
        if (isBraking)
        {
            if (rb.linearVelocity.magnitude > 0.05f)
                rb.AddForce(-rb.linearVelocity.normalized * braking,
                ForceMode.Acceleration);
        }
        else if (Mathf.Abs(throttleInput) > 0.01f &&
        Mathf.Abs(currentSpeed) < maxSpeed)
        {
            rb.AddForce(transform.forward * throttleInput * acceleration,
            ForceMode.Acceleration);
        }
    }
    void HandleSteer()
    {
        float speedFactor = Mathf.Clamp01(rb.linearVelocity.magnitude /
        maxSpeed);
        float turnAmount = steerInput * turnSpeed * speedFactor *
        Time.fixedDeltaTime;
        float moveDirection = Vector3.Dot(rb.linearVelocity,
        transform.forward); if (moveDirection < -0.1f) turnAmount = -turnAmount;
        transform.Rotate(Vector3.up * turnAmount);
    }
    void HandleGrip()
    {
        Vector3 lateralVelocity = Vector3.Project(rb.linearVelocity,
        transform.right);
        rb.AddForce(-lateralVelocity * grip, ForceMode.VelocityChange);
    }
}