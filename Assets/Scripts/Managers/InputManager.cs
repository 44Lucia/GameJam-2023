using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GameInput playerInput;
    public static InputManager _INPUT_MANAGER;

    //Movement Player 1
    private Vector2 currentMovementPlayer1Input;

    //Movement Player 2
    private Vector2 currentMovementPlayer2Input;

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

            playerInput.Character.MovePlayer1.performed += LeftAxisUpdate;
            playerInput.Character.MovePlayer2.performed += LeftAxisUpdate2;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        InputSystem.Update();
    }

    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        currentMovementPlayer1Input = context.ReadValue<Vector2>();
    }

    private void LeftAxisUpdate2(InputAction.CallbackContext context)
    {
        currentMovementPlayer2Input = context.ReadValue<Vector2>();
    }

    public Vector3 GetMovementButtonPressed() => this.currentMovementPlayer1Input;

    public Vector3 GetMovement2ButtonPressed() => this.currentMovementPlayer2Input;
}
