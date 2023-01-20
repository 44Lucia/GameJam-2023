using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField, Tooltip("Time in seconds")] private float timerTime;

    private int minutes, seconds;

    private void Update()
    {
        setTimerTime(timerTime);
        StartCoroutine(Counter());

        
    }

    public void setTimerTime(float time)
    {
        if (time < 0) { time = 0; }

        minutes = (int)(time / 60f);
        seconds = (int)(time - minutes * 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public IEnumerator Counter()
    {
        float time = timerTime;
        while (time > 0)
        {
            time -= Time.deltaTime;
            UIManager.Instance.GetTimerUI.setTimerTime(time);

            yield return null;
        }

        if (time <= 0)
        {
            if (GameManager._GAME_MANAGER.GetScorePlayer1 > GameManager._GAME_MANAGER.GetScorePlayer2)
            {
                Time.timeScale = 0f;
                GameManager._GAME_MANAGER.player1Win();
            }
            if (GameManager._GAME_MANAGER.GetScorePlayer2 > GameManager._GAME_MANAGER.GetScorePlayer1)
            {
                Time.timeScale = 0f;
                GameManager._GAME_MANAGER.player2Win();
            }
            if (GameManager._GAME_MANAGER.GetScorePlayer2 == GameManager._GAME_MANAGER.GetScorePlayer1)
            {
                Time.timeScale = 0f;
                GameManager._GAME_MANAGER.drawPlayers();
            }
        }
    }
}
