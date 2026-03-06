using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public int gearsRequired;
    private int gearsPlaced = 0;
    public GameObject door;
    public List<GearSpinner> gearScripts = new List<GearSpinner>();
    public void GearPlaced()
    {
        gearsPlaced++;
        Debug.Log("Kugghjul placerat! Totalt: " + gearsPlaced);

        if (gearsPlaced >= gearsRequired)
        {
            OpenDoor();
            StartGears();
        }
    }

    void StartGears()
    {
        foreach (GearSpinner gear in gearScripts)
        {
            gear.StartSpinning();
        }
    }
    void OpenDoor()
    {
        Debug.Log("Alla kugghjul på plats - Dörren öppnas!");
        // Instead of SetActive(false), let's slide it up:
        StartCoroutine(SlideDoor());
    }

    System.Collections.IEnumerator SlideDoor()
    {
        Vector3 openPosition = door.transform.position + new Vector3(0, 4.5f, 0);
        float speed = 2f;

        while (Vector3.Distance(door.transform.position, openPosition) > 0.01f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, openPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}