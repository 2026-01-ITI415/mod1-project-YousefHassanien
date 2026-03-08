using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // A slot in the Inspector to drop your boat into
    private Vector3 offset;   // This will store the distance between camera and boat

    void Start()
    {
        // Calculate the initial distance between the camera and the boat right when you hit Play
        offset = transform.position - player.transform.position;
    }

    void LateUpdate() 
    {
        // LateUpdate runs right AFTER the boat moves in FixedUpdate.
        // This ensures the camera follows smoothly without stuttering.
        transform.position = player.transform.position + offset;
    }
}