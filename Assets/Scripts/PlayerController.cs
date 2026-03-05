using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 LastCheckpoint;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        LastCheckpoint = transform.position;
    }

    public void SetCheckPoint(Vector3 checkpointPostion)
    {
        LastCheckpoint = checkpointPostion;

    }


    public void Respawn()
    {
        transform.position = LastCheckpoint;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    private void Update()
    {
        if (transform.position.y < -10f)
        {
            Respawn();
        }
    }
}
