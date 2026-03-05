using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{


    private bool unlocked = false;

    public void UnlockDoor()
    {
        unlocked = true;


        gameObject.SetActive(false);
    }


}
