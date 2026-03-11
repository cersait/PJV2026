using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Gjort Av Aiden
    private Vector3 LastCheckpoint;
    private Rigidbody2D rb;

    void Start()
    {
        // Får rigibody
        rb = GetComponent<Rigidbody2D>();
        //hittar det sista checkpoint och det blir positionen
        LastCheckpoint = transform.position;
    }

    public void SetCheckPoint(Vector3 checkpointPostion)
    {
        // Vad den checkpointen är
        LastCheckpoint = checkpointPostion;

    }


    public void Respawn()
    {
        // när man resetar på den checkpoint 
        transform.position = LastCheckpoint;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

   
}
