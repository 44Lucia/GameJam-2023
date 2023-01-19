using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBalls : MonoBehaviour
{
    [SerializeField] private GameObject upMaxPosition;
    [SerializeField] private GameObject downMaxPosition;

    [SerializeField] private int ballID;
    [SerializeField] private float yDirection;
    [SerializeField] private float speed;
    [SerializeField] private float maxPositionOffset;

    private Animator anim;

    private void Awake()
    {
        //Instantiate max positions
        upMaxPosition = new GameObject("DynamicBall" + ballID + "_UpMaxPosition");
        downMaxPosition = new GameObject("DynamicBall" + ballID + "_DownMaxPosition");
    }
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();

        //Set Max Positions
        upMaxPosition.transform.position = this.transform.position;
        upMaxPosition.transform.rotation = this.transform.rotation;
        upMaxPosition.transform.position = new Vector3(upMaxPosition.transform.position.x, upMaxPosition.transform.position.y + maxPositionOffset, upMaxPosition.transform.position.z);

        downMaxPosition.transform.position = this.transform.position;
        downMaxPosition.transform.rotation = this.transform.rotation;
        downMaxPosition.transform.position = new Vector3(downMaxPosition.transform.position.x, downMaxPosition.transform.position.y - maxPositionOffset, downMaxPosition.transform.position.z);

        this.gameObject.name = "DynamicBall_" + ballID.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.up * yDirection * speed * Time.deltaTime;

        if (yDirection == 1 && transform.position.y >= upMaxPosition.transform.position.y) 
        {
            yDirection = -1;
        }
        if (yDirection == -1 && transform.position.y <= downMaxPosition.transform.position.y)
        {
            yDirection = 1;
        }
    }
}
