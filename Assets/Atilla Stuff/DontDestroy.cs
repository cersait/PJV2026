using Unity.Cinemachine;
using UnityEngine;

public class DontDestroy : MonoBehaviour //Finds the camera a player when scene is switched
{
   void OnEnable()
   {
            // Find player and assign to vcam
            var vcam = GetComponent<CinemachineCamera>();
            vcam.Follow = GameObject.FindWithTag("Player").transform;
            vcam.LookAt = GameObject.FindWithTag("Player").transform;
   }
}