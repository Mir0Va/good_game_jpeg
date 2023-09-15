using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float MoveInputVector { get; private set; }
    public bool IsJumpButtonPressed { get; private set; } = false;
    public bool IsJumpButtonCanceled { get; private set; } = false;
    public bool IsWaveButtonPressed { get; private set; } = false;

    public void Move(InputAction.CallbackContext callbackContext)
    {
        MoveInputVector = callbackContext.ReadValue<Vector2>().x;
    }
    
    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            IsJumpButtonPressed = true;
            IsJumpButtonCanceled = false;
        }
        
        if (callbackContext.canceled)
        {
            IsJumpButtonCanceled = true;
            IsJumpButtonPressed = false;
        }
    }

    public void WaveForm(InputAction.CallbackContext callbackContext)
    {
        IsWaveButtonPressed = callbackContext.performed;
    }
    
}