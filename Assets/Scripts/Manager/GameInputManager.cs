using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInputManager : InputManager
{
    [SerializeField] private UIManager uiManager;
    public override void Start()
    {
        base.Start();
        GameInitialize();
    }
    public void GameInitialize()
    {
        uiManager.ShowReadyGoPanel();
        Time.timeScale = 1f;
    }
    public void GameStart()
    {
        uiManager.ShowGamePanel();
        Time.timeScale = 1f;
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GamePause()
    {
        uiManager.ShowPausePanel();
        Time.timeScale = 0f;
    }
    public void GameResume()
    {
        uiManager.HidePausePanel();
        Time.timeScale = 1f;
    }
}
