using UnityEngine;

public class TimeTracker : TimeObject, ITimeTravel
{
    [SerializeField] GameObject presentGameObject, pastGameObject;
    void Start()
    {
        presentGameObject.SetActive(true);

        pastGameObject.SetActive(false);
    }

    new public void TimeTravel(bool isPresent)
    {
        if(pastGameObject == null)
        {
            Destroy(presentGameObject);
        }
        else
        {
            pastGameObject.SetActive(!isPresent);
            if(presentGameObject != null)
            {
                presentGameObject.SetActive(isPresent);
            }
        }
    }
}
