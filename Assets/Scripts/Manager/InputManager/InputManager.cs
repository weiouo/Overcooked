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
    }
    public void Map()
    {
        SceneManager.LoadScene("Map");
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
