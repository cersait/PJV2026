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

    public void TimeTravel()
    {

    }
}
