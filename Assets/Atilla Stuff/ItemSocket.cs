using UnityEngine;

public class ItemSocket : MonoBehaviour
{
    public GameObject visualGear;
    private bool isActivated = false;
    private DoorManager doorManager;

    void Start()
    {
        doorManager = Object.FindFirstObjectByType<DoorManager>();
    }

    // Ändrad till 'bool' för att kunna svara drag-scriptet
    public bool Activate(GameObject uiIcon)
    {
        if (isActivated)
        {
            //Debug.Log("Denna maskin har redan ett kugghjul!");
            return false; // Säg nej till drag-scriptet
        }

        isActivated = true;
        uiIcon.SetActive(false);
        if (visualGear != null) visualGear.SetActive(true);

        if (doorManager != null) doorManager.GearPlaced();

        return true; // Säg ja, föremålet användes!
    }
}
