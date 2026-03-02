using UnityEngine;
public class AgingTimeObject : TimeObject, ITimeTravel
{
    [SerializeField] Color nowColor, oldColor;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = nowColor;
    }

    public void TimeTravel(bool isPresent) //toggles presneted information
    {
        //you can add extra conditions and variables incase you need to do something more complex
        if (isPresent == true)
        {
            sprite.color = nowColor;
        }
        else
        {
            sprite.color = oldColor;
        }
        print($"{gameObject.name} sucsessfully time traveled");
    }
}
