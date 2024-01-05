using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject TutorialPanel;
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
            HidePausePanel();
            Time.timeScale = 1f;
        }
        else
        {
            ShowPausePanel();
            Time.timeScale = 0f;
        }
    }
    public void ShowPausePanel()
    {
        PausePanel.SetActive(true);
    }
    public void HidePausePanel()
    {
        PausePanel.SetActive(false);
    }
    public void HideTutorialPanel()
    {
        TutorialPanel.SetActive(false);
    }
    public void ShowTutorialPanel()
    {
        TutorialPanel.SetActive(true);
    }
}
