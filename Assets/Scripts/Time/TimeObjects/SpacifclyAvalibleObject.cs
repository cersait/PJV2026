using UnityEngine;

public class SpacifclyAvalibleObject : TimeObject, ITimeTravel
{
    [SerializeField] bool isAvlibleInPresent = true;
    [SerializeField] GameObject[] targetGameObjects;

    private void Start()
    {

        for (int i = 0; i < targetGameObjects.Length; i++)
        {
            if (isAvlibleInPresent == true)
            {
                if (FindFirstObjectByType<TimeController>().isPresent == true)
                {
                    targetGameObjects[i].SetActive(true);
                }
                else
                {
                    targetGameObjects[i].SetActive(false);
                }
            }
            else
            {
                if (FindFirstObjectByType<TimeController>().isPresent == true)
                {
                    targetGameObjects[i].SetActive(false);
                }
                else
                {
                    targetGameObjects[i].SetActive(false);
                }
            }
        }
    }

    new public void TimeTravel(bool isPresent)
    {
        for (int i = 0; i < targetGameObjects.Length; i++)
        {
            if (targetGameObjects[i] != null)
            {
                if (isAvlibleInPresent == true)
                {
                    if (isPresent == true)
                    {
                        targetGameObjects[i].SetActive(true);
                    }
                    else
                    {
                        targetGameObjects[i].SetActive(false);
                    }
                }
                else
                {
                    if (isPresent == true)
                    {
                        targetGameObjects[i].SetActive(false);
                    }
                    else
                    {
                        targetGameObjects[i].SetActive(true);
                    }
                }
            }
        }
    }
}
