using UnityEngine;
using UnityEngine.SceneManagement;
using static Interfaces;
public class ArmoredDoor : TimeObject, ITimeTravel, IInteractible
{
    [SerializeField] Color presentColor, pastColor; //temp code
    //[SerializeField] Sprite presentSprite, pastSprite; cange later when needed sprites are avalible

    SpriteRenderer spriteRenderer;

    bool canProgess = false;
    [SerializeField] int nextLevel;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = presentColor;
    }

    new public void TimeTravel(bool isPresent)
    {
        if(isPresent == true)
        {
            spriteRenderer.color = presentColor;
            canProgess = false;
        }
        else
        {
            spriteRenderer.color = pastColor;
            canProgess = true;
        }
    }

    public void Interact()
    {
        if(canProgess == true)
        {
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInteract>() != null)
        {
            collision.gameObject.GetComponent<PlayerInteract>().currentInteractible = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerInteract>() != null)
        {
            collision.gameObject.GetComponent<PlayerInteract>().currentInteractible = null;
        }
    }
}
