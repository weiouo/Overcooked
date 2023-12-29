using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Camera MainCamera;
    [SerializeField] Camera SubCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchCamera();
        }
    }
    private void SwitchCamera()
    {
        MainCamera.enabled = !MainCamera.enabled;
        SubCamera.enabled = !SubCamera.enabled;
    }
}
