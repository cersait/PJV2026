using UnityEngine;

public interface ITimeTravel //every script that inherits from TimeObject should impliment this interface
{
    public void TimeTravel(bool isPresent); //should toggle objects between past and present
}

public class TimeObject : MonoBehaviour, ITimeTravel
{
    public void TimeTravel(bool isPresent)
    {
        print($"{gameObject.name} sucsessfully time traveled");
    }
}
