using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3.0f;
    public float waitTime = 1.0f; // Paus i sekunder

    private Vector3 target;
    private bool isWaiting = false;

    void Start()
    {
        target = pointB.position;
    }

    void FixedUpdate()
    {
        if (isWaiting) return;

        // Flytta plattformen
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);

        // Kolla om vi nått fram
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            StartCoroutine(WaitAndSwitch());
        }
    }

    IEnumerator WaitAndSwitch()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        // Byt målpunkt
        target = (target == pointA.position) ? pointB.position : pointA.position;
        isWaiting = false;
    }

    // FÅ SPELAREN ATT FÖLJA MED
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
