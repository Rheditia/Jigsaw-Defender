using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction lookAction;
    InputAction fireAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        fireAction = playerInput.actions["Fire"];
    }

    private void OnEnable()
    {
        moveAction.started += MoveInputHandler;
        moveAction.performed += MoveInputHandler;
        moveAction.canceled += MoveInputHandler;

        lookAction.performed += LookInputHandler;

        fireAction.started += FireInputHandler;
        fireAction.canceled += FireInputHandler;
    }

    private void OnDisable()
    {
        moveAction.started -= MoveInputHandler;
        moveAction.performed -= MoveInputHandler;
        moveAction.canceled -= MoveInputHandler;

        lookAction.performed -= LookInputHandler;

        fireAction.started -= FireInputHandler;
        fireAction.canceled -= FireInputHandler;
    }

    private void MoveInputHandler(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    private void LookInputHandler(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    private void FireInputHandler(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>() == 1);
    }
}
