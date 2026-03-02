using UnityEngine;

public class PlayerTimeController : MonoBehaviour
{
    [SerializeField] TimeController timeController;
    [SerializeField] KeyCode timeToggleInput = KeyCode.T; //input for toggling time
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(timeToggleInput)) //when time key is pressed
        {
            timeController.ChangeTime(); //change time
        }
    }
}
