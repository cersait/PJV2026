using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    //Aiden
    private bool checkpointReached = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !checkpointReached)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetCheckpoint(transform.position);
                checkpointReached = true;
            }
        }
    }
}
