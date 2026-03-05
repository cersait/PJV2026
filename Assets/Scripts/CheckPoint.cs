using UnityEngine;

public class CheckPoint : MonoBehaviour
{


    private bool checkpointReached = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !checkpointReached)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null)
            {
                player.SetCheckPoint(transform.position);
                checkpointReached = true;
            }
        }
    }

}
