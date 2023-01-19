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
    //Shoot Up Player 1
    private bool isShootingUpPlayer1;
    //Shoot Down Player 1
    private bool isShootingDownPlayer1;

    //Movement Player 2
    private Vector2 currentMovementPlayer2Input;
    //Shoot Up Player 1
    private bool isShootingUpPlayer2;
    //Shoot Down Player 1
    private bool isShootingDownPlayer2;

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
            playerInput.Character.ShootPlayer1Up.performed += ShootPlayer1UpUpdate;
            playerInput.Character.ShootPlayer1Down.performed += ShootPlayer1DownUpdate;

            playerInput.Character.MovePlayer2.performed += LeftAxisUpdate2;
            playerInput.Character.ShootPlayer2Up.performed += ShootPlayer2UpUpdate;
            playerInput.Character.ShootPlayer2Down.performed += ShootPlayer2DownUpdate;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        InputSystem.Update();
    }

    //Player 1

    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        currentMovementPlayer1Input = context.ReadValue<Vector2>();
    }

    private void ShootPlayer1UpUpdate(InputAction.CallbackContext context)
    {
        isShootingUpPlayer1 = !isShootingUpPlayer1;
    }

    private void ShootPlayer1DownUpdate(InputAction.CallbackContext context)
    {
        isShootingDownPlayer1 = !isShootingDownPlayer1;
    }


    //Player 2

    private void LeftAxisUpdate2(InputAction.CallbackContext context)
    {
        currentMovementPlayer2Input = context.ReadValue<Vector2>();
    }

    private void ShootPlayer2UpUpdate(InputAction.CallbackContext context)
    {
        isShootingUpPlayer2 = !isShootingUpPlayer2;
    }

    private void ShootPlayer2DownUpdate(InputAction.CallbackContext context)
    {
        isShootingDownPlayer2 = !isShootingDownPlayer2;
    }

    //Player 1
    public Vector3 GetMovementButtonPressed() => this.currentMovementPlayer1Input;
    public bool GetIsShootingUpPlayer1Pressed() => this.isShootingUpPlayer1 == true;
    public bool GetIsShootingDownPlayer1Pressed() => this.isShootingDownPlayer1 == true;

    //Player 2
    public Vector3 GetMovement2ButtonPressed() => this.currentMovementPlayer2Input;
    public bool GetIsShootingUpPlayer2Pressed() => this.isShootingUpPlayer2 == true;
    public bool GetIsShootingDownPlayer2Pressed() => this.isShootingDownPlayer2 == true;
}
