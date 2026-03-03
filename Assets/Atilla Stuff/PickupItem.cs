using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private bool isCarried = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCarried)
        {
            Transform holdPoint = other.transform.Find("HoldPoint");
            if (holdPoint != null)
            {
                Carry(holdPoint);
            }
        }
    }

    void Carry(Transform target)
    {
        isCarried = true;
        transform.SetParent(target);
        transform.localPosition = Vector3.zero;

        // Modern fysik-hantering (ersätter isKinematic = true)
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.bodyType = RigidbodyType2D.Kinematic;

        GetComponent<Collider2D>().enabled = false;
    }
}
