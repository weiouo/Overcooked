using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : GameInputManager
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OnPauseAction();
        }
    }
    public override void Start()
    {
        base.Start();
        GameInitialize();
    }
    private void OnPauseAction()
    {
        if (Time.timeScale == 0f)
            GameResume();
        else
            GamePause();
    }
}
