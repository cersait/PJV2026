using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField] private GameObject keypadUI;


    private bool unlocked = false;

    public void UnlockDoor()
    {
        unlocked = true;


        gameObject.SetActive(false);
    }


}
