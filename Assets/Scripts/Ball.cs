using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Singleton<Ball>
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float initialForce;
    [SerializeField] private Transform initPos;

    private void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        rb.AddForce(-transform.right * initialForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bounce
        SoundManager.Instance.PlayOnce(AudioClipName.BOUNCE_BALL);
        animator.SetBool("Idle", false);
    }

    public void SetInitPosition() 
    {
        gameObject.transform.position = initPos.position;
    }

    public void SetAnimatorIdleToTrue() { animator.SetBool("Idle", true); }

}
