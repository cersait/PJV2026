using Unity.Cinemachine;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject nextPortal;

    private bool playerIsOverlapping = false;
    private Transform playerTransform;

    [SerializeField] CinemachineCamera cam;
    [SerializeField] Transform playerCamTarget;   // Player follow target
    [SerializeField] Transform portalCamTarget;   // Camera position when teleported

    void Update()
    {
        if (playerIsOverlapping && Input.GetKeyDown(KeyCode.T))
        {
            // Teleport player
            playerTransform.position = nextPortal.transform.position;

            // Switch camera target
            if (cam.Follow == playerCamTarget)
            {
                cam.Follow = portalCamTarget;
            }
            else
            {
                cam.Follow = playerCamTarget;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsOverlapping = true;
            playerTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsOverlapping = false;
        }
    }
}