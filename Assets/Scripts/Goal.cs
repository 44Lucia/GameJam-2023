using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private bool isGoalPlayer1;
    [SerializeField] private bool isGoalPlayer2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoalPlayer1)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && isGoalPlayer1)
        {
            SoundManager.Instance.PlayOnce(AudioClipName.POINT);
            GameManager._GAME_MANAGER.addPointsPlayer1(1);
            PlayerController.Instance.SetInitPosition();
            StartCoroutine(SetBallPosition());
        }

        if (collision.CompareTag("Ball") && isGoalPlayer2)
        {
            SoundManager.Instance.PlayOnce(AudioClipName.POINT);
            GameManager._GAME_MANAGER.addPointsPlayer2(1);
            Player2Controller.Instance.SetInitPosition();
            StartCoroutine(SetBallPosition());
        }
    }

    public IEnumerator SetBallPosition()
    {
        yield return new WaitForSeconds(1.5f);
        Ball.Instance.SetInitPosition();
    }
}
