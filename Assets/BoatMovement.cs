using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatMovement : MonoBehaviour
{
    public float forwardSpeed = 500f; 
    public float dodgeSpeed = 300f;   
    private Rigidbody rb;
    
    // A boolean to check if the game is over so we stop adding force
    private bool isFinished = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        // Only allow movement if the game is NOT finished
        if (!isFinished) 
        {
            rb.AddForce(Vector3.forward * forwardSpeed * Time.deltaTime);

            float horizontalInput = Input.GetAxis("Horizontal"); 
            rb.AddForce(Vector3.right * horizontalInput * dodgeSpeed * Time.deltaTime);
        }
    }

void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drain"))
        {
            RestartGame();
        }
        else if (other.CompareTag("Finish"))
        {
            // 1. The boat crossed the finish line!
            isFinished = true; 

            // 2. Kill all built-up momentum instantly by turning on isKinematic
            rb.isKinematic = true; 

            // 3. Wait 3 seconds, then restart
            Invoke("RestartGame", 3f); 
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}