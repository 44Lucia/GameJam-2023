using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Manager")]
    private InputManager input;
    private CharacterController player;

    private Vector3 direction;
    private Vector3 finalVelocity = Vector3.zero;

    [Header("PlayerParameters")]
    [SerializeField]private float speed;
    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager._INPUT_MANAGER;

        player = GetComponent<CharacterController>();

        //Default values movement
        finalVelocity = Vector3.zero;
        if (speed == 0f) { speed = 1f; }
        if (maxSpeed == 0f) { maxSpeed = 15f; }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        player.Move(finalVelocity * Time.deltaTime);
    }

    private void Move()
    {
        //GetAxis: calcular velocidad de X y Z
        direction = new Vector3(input.GetMovementButtonPressed().x, direction.y, input.GetMovementButtonPressed().y);
        direction.y = -1f;
        direction.Normalize();

        //Velocidad final XZ
        finalVelocity.x = direction.x * speed;
        finalVelocity.z = direction.z * speed;
    }
}
