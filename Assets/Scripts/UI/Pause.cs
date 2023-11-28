using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause  : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject pauseMenu;
    private static bool isPause = false;

    // Start is called before the first frame update
    public void Start()
    {
        gameInput.OnPauseAction += GameInput_OnPauseAction;
        pauseMenu.SetActive(false);
    }
    //«öesc°õ¦æPause
    private void GameInput_OnPauseAction(object sender, System.EventArgs e)
    {
        if (isPause)
        {
            GameResume();
        }
        else
        {
            GamePause();
        }
    }
    public void GameResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
    public void GamePause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 1f;
    }
}
