using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Singleton<Goal>
{
    [SerializeField] private bool isGoalPlayer1;
    [SerializeField] private bool isGoalPlayer2;    

    [SerializeField] private GameObject canvasPlayer1;
    [SerializeField] private GameObject canvasPlayer2;

    private void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        canvasPlayer1.SetActive(false);
        canvasPlayer2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && isGoalPlayer1)
        {
            SoundManager.Instance.PlayOnce(AudioClipName.POINT);
            GameManager._GAME_MANAGER.addPointsPlayer1(1);
            PlayerController.Instance.SetInitPosition();
            Ball.Instance.SetTargetIsPlayer2(true);
            StartCoroutine(SetBallPosition());
        }

        if (collision.CompareTag("Ball") && isGoalPlayer2)
        {
            SoundManager.Instance.PlayOnce(AudioClipName.POINT);
            GameManager._GAME_MANAGER.addPointsPlayer2(1);
            Player2Controller.Instance.SetInitPosition();
            Ball.Instance.SetTargetIsPlayer2(false);
            StartCoroutine(SetBallPosition());
        }
    }

    public IEnumerator SetBallPosition()
    {
        yield return new WaitForSeconds(1.5f);
        Ball.Instance.SetInitPosition();
    }

    public GameObject SetCanvasWinPlayer1 { get => canvasPlayer1; set => canvasPlayer1 = value; }
    public GameObject SetCanvasWinPlayer2 { get => canvasPlayer2; set => canvasPlayer2 = value; }
}
