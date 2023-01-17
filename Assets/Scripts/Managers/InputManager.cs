using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GameInput playerInput;
    public static InputManager _INPUT_MANAGER;

    //Jump
    private float timeSinceJumppPressed = 0f;

    //Movement
    private Vector2 currentMovementInput;

    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(_INPUT_MANAGER);
        }
        else
        {
            playerInput = new GameInput();
            playerInput.Character.Enable();

            playerInput.Character.Jump.performed += JumpButtonPressed;
            playerInput.Character.Move.performed += LeftAxisUpdate;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        timeSinceJumppPressed += Time.deltaTime;

        InputSystem.Update();
    }

    private void JumpButtonPressed(InputAction.CallbackContext context)
    {
        timeSinceJumppPressed = 0f;
    }

    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
    }

    public bool GetSouthButtonPressed() => this.timeSinceJumppPressed == 0f;

    public Vector3 GetMovementButtonPressed() => this.currentMovementInput;
}
