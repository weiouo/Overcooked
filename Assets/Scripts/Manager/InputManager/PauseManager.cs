using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OnPauseAction();
        }
    }
    private void OnPauseAction()
    {
        if (Time.timeScale == 0f)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
