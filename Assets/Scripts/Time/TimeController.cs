using UnityEngine;
using UnityEngine.Rendering;
using static TimeObject;
public class TimeController : MonoBehaviour
{
    public bool isPresent = true;
    [SerializeField] TimeObject[] timeObjects;

    [SerializeField] Volume v;
    [SerializeField] float GFXeffectCooldown = 0.5f;
    float GFXeffectCooldownReset;

    [SerializeField] AudioSource radioStatic;

    private void Start()
    {
        timeObjects = FindObjectsByType<TimeObject>(FindObjectsInactive.Include ,FindObjectsSortMode.InstanceID);
        GFXeffectCooldownReset = GFXeffectCooldown;
        GFXeffectCooldown = 0;
    }

    private void Update()
    {
        v.weight = GFXeffectCooldown / GFXeffectCooldownReset;
        radioStatic.volume = GFXeffectCooldown / GFXeffectCooldownReset;
        if(GFXeffectCooldown > 0)
        {
            GFXeffectCooldown -= Time.deltaTime;
        }
        else
        {
            GFXeffectCooldown = 0;
        }
    }

    public void ChangeTime() //toggles between the present and past
    {
        isPresent = !isPresent;
        for (int i = 0; i < timeObjects.Length; i++)
        {
            ITimeTravel timeTravelelingObject = timeObjects[i]; //saves current time object as an ITimeTravel interface
            timeTravelelingObject.TimeTravel(isPresent); //call the objects TimeTravel function
        }
        GFXeffectCooldown = GFXeffectCooldownReset;
        if(radioStatic != null)
        {
            radioStatic.Play();
        }
    }
}
