using UnityEngine;

public class ResetPlayerButton : MonoBehaviour
{

    // Gjort av Aiden
    [SerializeField] private PlayerController player;
    [SerializeField] private PauseMenu Pause;

    public void ResetPlayer()
    {

        // Om spelaren trycker på reset knapp och spelaren finns så startar om spelen om du inte hade fått en checkpoint innan dess.
        if (player != null)
        {
            player.Respawn();
            
        }
        if (player != null)
        {

            Pause.Resume();
        }

    }
    // om spelaren ramlar så respawnar automatiskt 
    void Update()
    {
        if (transform.position.y < -10f)
        {
           player.Respawn();
        }
    }

}
