using UnityEngine;
public class AgingTimeObject : TimeObject, ITimeTravel
{
    [SerializeField] Color nowColor, oldColor;
    [SerializeField] Sprite presentSprite, pastSprite;
    SpriteRenderer renderer;
    
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();

        if(FindFirstObjectByType<TimeController>().isPresent == true)
        {
            renderer.color = nowColor;
            renderer.sprite = presentSprite;
        }
        else
        {
            renderer.color = oldColor;
            renderer.sprite = presentSprite;
        }
        
    }

    new public void TimeTravel(bool isPresent) //toggles presneted information
    {
        //you can add extra conditions and variables incase you need to do something more complex
        if (isPresent == true)
        {
            renderer.color = nowColor;
            renderer.sprite = presentSprite;
        }
        else
        {
            renderer.color = oldColor;
            renderer.sprite = pastSprite;
        }
        print($"{gameObject.name} sucsessfully time traveled");
    }
}
