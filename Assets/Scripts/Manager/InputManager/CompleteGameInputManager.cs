using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGameInputManager : GameInputManager
{
    [SerializeField] private GameInput gameInput;
    public override void Start()
    {
        base.Start();
        GameInitialize();
        gameInput.OnPauseAction += GameInput_OnPauseAction;
    }
    private void GameInput_OnPauseAction(object sender, System.EventArgs e)
    {
        if (Time.timeScale == 0f)
            GameResume();
        else
            GamePause();
    }
}
