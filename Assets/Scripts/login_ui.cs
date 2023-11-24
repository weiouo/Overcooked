using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class login_ui : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene(1);
    }
    public void map()
    {

    }
    public void exit()
    {
        Application.Quit();
    }
}
