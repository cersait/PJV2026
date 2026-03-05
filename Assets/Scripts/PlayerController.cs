using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //aiden
    private Vector3 lastCheckpoint;

    private void Start()
    {
        // Initialize the checkpoint to starting position
        lastCheckpoint = transform.position;
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
        Debug.Log("Checkpoint reached at: " + lastCheckpoint);
    }

    public void ResetToCheckpoint()
    {
        transform.position = lastCheckpoint;
        // Optional: reset velocity if using Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
