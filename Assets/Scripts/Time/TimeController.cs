using UnityEngine;
using UnityEngine.Rendering;
using static TimeObject;
public class TimeController : MonoBehaviour
{
    public bool isPresent = true;
    [SerializeField] TimeObject[] timeObjects;

    [SerializeField] Volume v;

    private void Start()
    {
        timeObjects = FindObjectsByType<TimeObject>(FindObjectsInactive.Include ,FindObjectsSortMode.InstanceID);
    }

    public void ChangeTime() //toggles between the present and past
    {
        isPresent = !isPresent;
        for (int i = 0; i < timeObjects.Length; i++)
        {
            ITimeTravel timeTravelelingObject = timeObjects[i]; //saves current time object as an ITimeTravel interface
            timeTravelelingObject.TimeTravel(isPresent); //call the objects TimeTravel function
        }
    }
}
