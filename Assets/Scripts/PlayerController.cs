using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Manager")]
    private InputManager input;

    private Vector3 direction;
    private Vector3 finalVelocity = Vector3.zero;

    [Header("PlayerParameters")]
    private float speed;
    private float maxSpeed;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager._INPUT_MANAGER;

        rb2d = GetComponent<Rigidbody2D>();

        //Default values movement
        finalVelocity = Vector3.zero;
        if (speed == 0f) { speed = 1f; }
        if (maxSpeed == 0f) { maxSpeed = 15f; }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
    }
}
