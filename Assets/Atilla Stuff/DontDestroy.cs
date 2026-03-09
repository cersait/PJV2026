using Unity.Cinemachine;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
   void OnEnable()
   {
            // Find player and assign to vcam
            var vcam = GetComponent<CinemachineCamera>();
            vcam.Follow = GameObject.FindWithTag("Player").transform;
            vcam.LookAt = GameObject.FindWithTag("Player").transform;
   }
}