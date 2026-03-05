using UnityEngine;

public class ResetPlayerButton : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private PauseMenu Pause;

    public void ResetPlayer()
    {
        if (player != null)
        {
            player.Respawn();
            
        }
        if (player != null)
        {

            Pause.Resume();
        }

    }

    
}
