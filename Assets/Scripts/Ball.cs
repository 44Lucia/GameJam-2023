using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Vector3 finalVelocity;
    private float speed;
    private Rigidbody2D rb;
    [SerializeField] private float initialForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        rb.AddForce(-transform.right * initialForce);
    }

    // Update is called once per frame
    /*private void Update()
    {
           
    }*/

}
