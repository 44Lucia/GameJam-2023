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
    private int timerArmUp;
    [SerializeField] private Rigidbody2D armDown;
    private int timerArmDown;

    [Header("Colliders")]
    [SerializeField] private GameObject topMapLimit;
    [SerializeField] private GameObject bottomMapLimit;
    //[SerializeField] private GameObject leftMapLimit;
    //[SerializeField] private GameObject rightMapLimit;

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

        //Ignore collision between flippers and map limits
        Physics2D.IgnoreCollision(topMapLimit.GetComponent<Collider2D>(), armUp.gameObject.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(topMapLimit.GetComponent<Collider2D>(), armDown.gameObject.GetComponent<Collider2D>(), true);

        Physics2D.IgnoreCollision(bottomMapLimit.GetComponent<Collider2D>(), armUp.gameObject.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(bottomMapLimit.GetComponent<Collider2D>(), armDown.gameObject.GetComponent<Collider2D>(), true);

        /*Physics2D.IgnoreCollision(leftMapLimit.GetComponent<Collider2D>(), armUp.gameObject.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(leftMapLimit.GetComponent<Collider2D>(), armDown.gameObject.GetComponent<Collider2D>(), true);

        Physics2D.IgnoreCollision(rightMapLimit.GetComponent<Collider2D>(), armUp.gameObject.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(rightMapLimit.GetComponent<Collider2D>(), armDown.gameObject.GetComponent<Collider2D>(), true);*/

        //Default values movement
        finalVelocity = Vector3.zero;
        timerArmDown = 0;
        timerArmDown = 0;
        armDown.gravityScale = 0;
        if (speed == 0f) { speed = 1f; }
        if (maxSpeed == 0f) { maxSpeed = 15f; }
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetResetBallUpdate()) 
        {
            Ball.Instance.SetInitPosition();
            Ball.Instance.AddForceWithRandomDirection();
        }

        Move();

        if (input.GetIsShootingUpPlayer1Pressed())
        {
            if (timerArmUp == 0){ SoundAttack(); }
            timerArmUp++;
            armUp.AddTorque(10000000);
        }
        else { armUp.AddTorque(-10000000); timerArmUp = 0; }

        if (input.GetIsShootingDownPlayer1Pressed())
        {
            if (timerArmDown == 0){ SoundAttack(); }
            timerArmDown++;
            armDown.gravityScale = 1;
            armDown.AddTorque(-10000000);
        }
        else { armDown.gravityScale = 0; armDown.AddTorque(10000000); timerArmDown = 0; }

        player.Move(finalVelocity * Time.deltaTime);
    }

    private void SoundAttack() { SoundManager.Instance.PlayOnce(AudioClipName.PLAYER_ATTACK); }

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
