using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public virtual void Start() { }
    public void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;
    }
    public void Map()
    {
        SceneManager.LoadScene("Map");
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
