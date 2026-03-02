using UnityEngine;

public class PlayerTimeController : MonoBehaviour
{
    [SerializeField] TimeController timeController;
    [SerializeField] KeyCode timeToggleInput = KeyCode.T; //input for toggling time

    [SerializeField] float inputCooldown = 0.5f;
    float inputCooldownreset;

    private void Start()
    {
        inputCooldownreset = inputCooldown;
    }

    void Update()
    {
        if (Input.GetKeyDown(timeToggleInput) && inputCooldown < 0) //when time key is pressed
        {
            timeController.ChangeTime(); //change time
            inputCooldown = inputCooldownreset;
        }
        else
        {
            inputCooldown -= Time.deltaTime;
        }
    }
}
