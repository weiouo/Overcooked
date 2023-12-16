using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject readyGoPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject timesUpPanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private UnityEvent setupEndPanel;
    public void ShowReadyGoPanel()
    {
        HideAllPanel();
        readyGoPanel.SetActive(true);
    }
    public void ShowGamePanel()
    {
        HideAllPanel();
        gamePanel.SetActive(true);
    }
    public void ShowTimesUpPanel()
    {
        timesUpPanel.SetActive(true);
    }
    public void ShowEndPanel()
    {
        HideAllPanel();
        endPanel.SetActive(true);
        setupEndPanel.Invoke();
    }
    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
    }
    public void HidePausePanel()
    {
        pausePanel.SetActive(false) ;
    }
    public void HideAllPanel()
    {
        readyGoPanel.SetActive(false);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
}
