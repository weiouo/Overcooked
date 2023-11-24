using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class pause_ui : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pausemenu;
    // Start is called before the first frame update
    public void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    public void pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    public void restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void quit()
    {
        Application.Quit();
        Time.timeScale = 1f;
    }
}
