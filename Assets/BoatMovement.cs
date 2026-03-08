using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatMovement : MonoBehaviour
{
    public float forwardSpeed = 500f; 
    public float dodgeSpeed = 300f;   
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        // 1. Constant forward drift
        rb.AddForce(Vector3.forward * forwardSpeed * Time.deltaTime);

        // 2. Lateral dodging
        float horizontalInput = Input.GetAxis("Horizontal"); 
        rb.AddForce(Vector3.right * horizontalInput * dodgeSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Restart if we hit a storm drain
        if (other.CompareTag("Drain"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}