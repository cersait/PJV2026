using UnityEngine;
using static TimeObject;
public class TimeController : MonoBehaviour
{
    public bool isPresent = true;
    [SerializeField] TimeObject[] timeObjects;

    private void Start()
    {
        Invoke("ChangeTime", 2);
    }

    public void ChangeTime() //toggles between the present and past
    {
        isPresent = !isPresent;
        for (int i = 0; i < timeObjects.Length; i++)
        {
            TimeObject timeObject = timeObjects[i];
            ITimeTravel timeTravelelingObject = timeObject as ITimeTravel;
            timeTravelelingObject.TimeTravel(isPresent);
        }
    }
}
