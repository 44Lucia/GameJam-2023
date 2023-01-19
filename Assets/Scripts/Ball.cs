using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float initialForce;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bounce
        animator.SetBool("Idle", false);
    }

    public void SetAnimatorIdleToTrue() { animator.SetBool("Idle", true); }

}
