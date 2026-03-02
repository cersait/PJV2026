using UnityEngine;

public interface ITimeTravel //every script that inherits from TimeObject should impliment this interface
{
    void TimeTravel(bool isPresent); //should toggle objects between past and present
}

public class TimeObject : MonoBehaviour
{
    [SerializeField] protected TimeController timeController;
}
