using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDetector : MonoBehaviour
{
    [SerializeField] private GameObject LevelDataPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelDataPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelDataPanel.SetActive(false);
        }
    }
}
