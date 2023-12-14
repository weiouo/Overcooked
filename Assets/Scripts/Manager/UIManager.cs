using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject readyGoPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject pausePanel;
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
    public void ShowEndPanel()
    {
        HideAllPanel();
        endPanel.SetActive(true);
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
