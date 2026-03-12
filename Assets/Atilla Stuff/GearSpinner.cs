using UnityEngine;

public class GearSpinner : MonoBehaviour //spins gears
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

    void Update() //manages so the gears placed in spinRight and spinLeft to spin at those certain directions
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
            
        }
    }
}