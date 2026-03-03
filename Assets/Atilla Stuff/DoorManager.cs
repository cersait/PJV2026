using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public int gearsRequired = 3;
    private int gearsPlaced = 0;
    public GameObject door;

    public void GearPlaced()
    {
        gearsPlaced++;
        Debug.Log("Kugghjul placerat! Totalt: " + gearsPlaced);

        if (gearsPlaced >= gearsRequired)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        door.SetActive(false); // Eller kör en animation
        Debug.Log("Alla kugghjul på plats - Dörren öppnas!");
    }
}
