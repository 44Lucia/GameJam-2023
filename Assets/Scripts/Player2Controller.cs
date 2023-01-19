using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : Singleton<Player2Controller>
{
    [Header("Manager")]
    private InputManager input;
    private CharacterController player;

    private Vector3 direction;
    private Vector3 finalVelocity = Vector3.zero;

    [Header("PlayerParameters")]
    [SerializeField]private float speed;
    private float maxSpeed;
    [SerializeField] private Transform initPos;

    [Header("Flippers")]
    [SerializeField] private Rigidbody2D armUp;
    [SerializeField] private Rigidbody2D armDown;

    private void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager._INPUT_MANAGER;

        player = GetComponent<CharacterController>();

        //Default values movement
        finalVelocity = Vector3.zero;
        armDown.gravityScale = 0;
        if (speed == 0f) { speed = 1f; }
        if (maxSpeed == 0f) { maxSpeed = 15f; }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (input.GetIsShootingUpPlayer2Pressed())
        {
            armUp.AddTorque(-1000);
        }
        else { armUp.AddTorque(1000); }

        if (input.GetIsShootingDownPlayer2Pressed())
        {
            armDown.gravityScale = 1;
            armDown.AddTorque(1000);
        }
        else { armDown.gravityScale = 0; armDown.AddTorque(-1000); }

        player.Move(finalVelocity * Time.deltaTime);
    }

    private void Move()
    {
        //GetAxis: calcular velocidad de X y Z
        direction = new Vector3(direction.x, input.GetMovement2ButtonPressed().y, direction.z);
        direction.Normalize();

        //Velocidad final XZ
        finalVelocity.y = direction.y * speed;
    }

    public void SetInitPosition() 
    {
        player.enabled = false;
        player.transform.position = initPos.position;
        player.enabled = true;
    }
}
