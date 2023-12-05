using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputControl playerInputControl;
    public event EventHandler OnInteractAction;
    public event EventHandler OnCutAction;
    public event EventHandler OnPauseAction;

    private void Awake()
    {
        playerInputControl = new PlayerInputControl();
        playerInputControl.Player.Enable();

        playerInputControl.Player.Interact.performed += Interact_performed;
        playerInputControl.Player.Cut.performed += Cut_performed;
        playerInputControl.Player.Pause.performed += Pause_performed;
    }

    private void OnDestroy()
    {
        // 在物件被銷毀時解除事件註冊
        playerInputControl.Player.Interact.performed -= Interact_performed;
        playerInputControl.Player.Cut.performed -= Cut_performed;
        playerInputControl.Player.Pause.performed -= Pause_performed;
    }
    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }
    private void Cut_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnCutAction?.Invoke(this, EventArgs.Empty);
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputControl.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
