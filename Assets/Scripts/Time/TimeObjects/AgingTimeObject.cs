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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimeTravel(bool isPresent)
    {
        if(isPresent == true)
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
