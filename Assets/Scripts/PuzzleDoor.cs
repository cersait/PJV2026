using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    // Aiden
    public void UnlockDoor()
    {
        // Tar bort dörren/ Öppnar dörren
        Debug.Log("Door Unlocked");
        gameObject.SetActive(false);
    }


}
