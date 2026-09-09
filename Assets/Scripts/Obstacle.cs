using UnityEngine;
public class Obstacle : MonoBehaviour
{
// Start is called once before the first execution of Update after the MonoBehaviouris created
[Header("Lifetime")]
public float lifeTime = 6f;
    [Header("Fall / Initial Push")]
    public bool applyInitialPush = true;
    public Vector3 initialPushForce = new Vector3(2f, 0f, 2f);
    public float initialTorque = 5f;
    [Header("Push On Player Hit")]
    public float hitPushForce = 10f;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Destroy(gameObject, lifeTime);
        if (applyInitialPush)
        {
            Vector3 randomPush = new Vector3(
            Random.Range(-initialPushForce.x, initialPushForce.x),
            0f,
            Random.Range(-initialPushForce.z, initialPushForce.z)
            );
            rb.AddForce(randomPush, ForceMode.Impulse);
            Vector3 randomTorque = new Vector3(
            Random.Range(-initialTorque, initialTorque),
            Random.Range(-initialTorque, initialTorque),
            Random.Range(-initialTorque, initialTorque)
            );
            rb.AddTorque(randomTorque, ForceMode.Impulse);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.OnPlayerHit();
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 pushDir = (collision.transform.position -
                transform.position).normalized;
                pushDir.y = 0f;
                playerRb.AddForce(pushDir * hitPushForce, ForceMode.Impulse);
            }
        }
    }
}