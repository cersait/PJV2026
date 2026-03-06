using UnityEngine;

public class GearSpinner : MonoBehaviour
{
    // gjort av Atilla Tokat
    public float spinSpeed = 100f;
    private bool isSpinning = false;
    public GameObject spinRight;
    public GameObject spinLeft;
    // This is called by the DoorManager
    public void StartSpinning()
    {
        isSpinning = true;
    }

    void Update()
    {
        if (isSpinning)
        {
            if (spinRight != null)
            {
                spinRight.transform.Rotate(Vector3.back * spinSpeed * Time.deltaTime);
            }
            if (spinLeft != null)
            {
                transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
            }
            // Rotates the gear around its Y-axis (adjust Vector3 if your gear is oriented differently)
            
        }
    }
}