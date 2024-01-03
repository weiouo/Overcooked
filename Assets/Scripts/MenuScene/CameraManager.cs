using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera StartCamera;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Camera SubCamera;
    private void Start()
    {
        SwitchToCamera(StartCamera);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (MainCamera.enabled == true)
                SwitchToCamera(SubCamera);
            else
                SwitchToCamera(MainCamera);
        }
    }
    private void SwitchToCamera(Camera camera)
    {
        StartCamera.enabled = false;
        MainCamera.enabled = false;
        SubCamera.enabled = false;
        camera.enabled = true;
    }
    public void SwitchToMainCamera()
    {
        SwitchToCamera(MainCamera);
    }
}
