using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Singleton<Ball>
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private float initialForce;
    [SerializeField] private Transform currentInitPos;
    [SerializeField] private Transform initPosPlayer1;
    [SerializeField] private Transform initPosPlayer2;

    [SerializeField] private float minRandomDir;
    [SerializeField] private float maxRandomDir;

    //[SerializeField] private bool targetIsPlayer1;
    [SerializeField] private bool targetIsPlayer2;


    private void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        SetInitPosition();
        AddForceWithRandomDirection();
    }

    public void AddForceWithRandomDirection() 
    {
        transform.eulerAngles = Vector3.zero;
        //Debug.Log("VEL" + rb.velocity);
        rb.velocity = Vector3.zero;
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(minRandomDir, maxRandomDir));
        //Debug.Log(transform.eulerAngles.z);
        Vector3 force = -transform.right;
        if (targetIsPlayer2) { force = transform.right; }
        rb.AddForce(force * initialForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bounce
        SoundManager.Instance.PlayOnce(AudioClipName.BOUNCE_BALL);
        animator.SetBool("Idle", false);
    }

    public void SetInitPosition() 
    {
        currentInitPos = initPosPlayer1;
        if (targetIsPlayer2) { currentInitPos = initPosPlayer2; }
        gameObject.transform.position = currentInitPos.position;
    }

    public void SetTargetIsPlayer2(bool _targetIsPlayer2) { targetIsPlayer2 = _targetIsPlayer2; }

    public void SetAnimatorIdleToTrue() { animator.SetBool("Idle", true); }

    public void SetVisibility(bool visible) { GetComponent<SpriteRenderer>().enabled = visible; }

}
