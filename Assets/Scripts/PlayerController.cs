using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Manager")]
    private InputManager input;
    private CharacterController player;

    private Vector3 direction;
    private Vector3 finalVelocity = Vector3.zero;

    [Header("PlayerParameters")]
    [SerializeField] private float speed;
    private float maxSpeed;
    [SerializeField] private Transform initPos;

    [Header("Flippers")]
    [SerializeField] private Rigidbody2D armUp;
    [SerializeField] private Rigidbody2D armDown;

    [Header("Colliders")]
    [SerializeField] private GameObject tilemapCollisionGO;

    [Header("Max Position")]
    [SerializeField] private float bottomMaxPosition;
    [SerializeField] private float topMaxPosition;

    private void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager._INPUT_MANAGER;

        player = GetComponent<CharacterController>();

        //Ignore collision between flippers and tilemap collider
        Physics2D.IgnoreCollision(tilemapCollisionGO.GetComponent<Collider2D>(), armUp.gameObject.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(tilemapCollisionGO.GetComponent<Collider2D>(), armDown.gameObject.GetComponent<Collider2D>(), true);

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

        if (input.GetIsShootingUpPlayer1Pressed())
        {
            armUp.AddTorque(100000);
        }
        else { armUp.AddTorque(-100000); }

        if (input.GetIsShootingDownPlayer1Pressed())
        {
            armDown.gravityScale = 1;
            armDown.AddTorque(-100000);
        }
        else { armDown.gravityScale = 0; armDown.AddTorque(100000); }

        player.Move(finalVelocity * Time.deltaTime);
    }

    private void Move()
    {
        //GetAxis: calcular velocidad de X y Z
        direction = new Vector3(direction.x, input.GetMovementButtonPressed().y, direction.z);
        direction.Normalize();

        //Velocidad final Y
        finalVelocity.y = direction.y * speed;


        //Clamp position
        if (finalVelocity.y > 0 && transform.position.y >= topMaxPosition) // Going up
        {
            //Debug.Log("At max position");
            finalVelocity.y = 0;
        }
        else if (finalVelocity.y < 0 && transform.position.y <= bottomMaxPosition) // Going down
        {
            //Debug.Log("At max position");
            finalVelocity.y = 0;
        }
    }

    public void SetInitPosition()
    {
        player.enabled = false;
        player.transform.position = initPos.position;
        player.enabled = true;
    }
}
