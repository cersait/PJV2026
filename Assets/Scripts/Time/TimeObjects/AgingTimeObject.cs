using UnityEngine;
public class AgingTimeObject : TimeObject, ITimeTravel
{
    [SerializeField] Color nowColor, oldColor;
    [SerializeField] Sprite presentSprite, pastSprite;
    SpriteRenderer renderer;
    
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();

        if(TimeController.isPresent == true)
        {
            renderer.color = nowColor;
            renderer.sprite = presentSprite;
        }
        else
        {
            renderer.color = oldColor;
            renderer.sprite = presentSprite;
        }
        
        if(renderer == null)
        {
            print($"{gameObject.name}... WHY DO YOU NOT HAVE A RENDERER");
        }

        if(presentSprite == null)
        {
            print($"{gameObject.name} has no present sprite");
        }


        if(pastSprite == null)
        {
            print($"{gameObject.name} has no past sprite");
        }

        if(oldColor == null)
        {
            print($"{gameObject.name} has no old color");
        }

        if(nowColor == null)
        {
            print($"{gameObject.name} has no now color");
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
