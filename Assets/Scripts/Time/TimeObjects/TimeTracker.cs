using UnityEngine;

public class TimeTracker : TimeObject, ITimeTravel
{
    [SerializeField] GameObject presentGameObject, pastGameObject;
    void Start()
    {
        presentGameObject.SetActive(TimeController.isPresent);

        pastGameObject.SetActive(!TimeController.isPresent);
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
