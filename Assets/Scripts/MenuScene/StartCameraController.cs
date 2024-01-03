using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraController : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    public void SwitchToMainCamera()
    {
        cameraManager.SwitchToMainCamera();
    }
    public void CloseStartCamera()
    {
        this.gameObject.SetActive(false);
    }
}
