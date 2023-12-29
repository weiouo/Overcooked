using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInputManager : InputManager
{
    [SerializeField] private PanelController panelController;
    public void GameInitialize()
    {
        panelController.ShowReadyGoPanel();
        Time.timeScale = 1f;
    }
    public void GameStart()
    {
        panelController.ShowGamePanel();
        Time.timeScale = 1f;
    }
    public void GameTimesUp()
    {
        panelController.ShowTimesUpPanel();
    }
    public void GameEnd()
    {
        panelController.ShowEndPanel();
        Time.timeScale = 0f;
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void GamePause()
    {
        panelController.ShowPausePanel();
        Time.timeScale = 0f;
    }
    public void GameResume()
    {
        panelController.HidePausePanel();
        Time.timeScale = 1f;
    }
    public void GameTutorialOn()
    {
        panelController.ShowTutorialPanel();
        Time.timeScale = 0f;
    }
    public void GameTutorialOff()
    {
        panelController.HideTutorialPanel();
        Time.timeScale = 1f;
    }
}
