using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour //manages the door opening sequence
{

    // gjort av Atilla Tokat
    public int gearsRequired;
    private int gearsPlaced = 0;
    public GameObject door;
    public List<GearSpinner> gearScripts = new List<GearSpinner>();
    public void GearPlaced() //tracks if gears are placed
    {
        gearsPlaced++;
        Debug.Log("Kugghjul placerat! Totalt: " + gearsPlaced);

        if (gearsPlaced >= gearsRequired)
        {
            OpenDoor();
            StartGears();
        }
    }

    void StartGears() //starts the GearSpinner script when all the gears are placed
    {
        foreach (GearSpinner gear in gearScripts)
        {
            gear.StartSpinning();
        }
    }
    void OpenDoor() //opens the door
    {
        Debug.Log("Alla kugghjul på plats - Dörren öppnas!");
        // Instead of SetActive(false), let's slide it up:
        StartCoroutine(SlideDoor());
    }

    System.Collections.IEnumerator SlideDoor() //transforms the door to slide up and stop at a certain position
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