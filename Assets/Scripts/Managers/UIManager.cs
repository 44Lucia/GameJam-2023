using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TimerUI timerUI;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private TMP_Text scorePlayer1;
    [SerializeField] private TMP_Text scorePlayer2;

    private void Update()
    {
        scorePlayer1.text = GameManager._GAME_MANAGER.GetScorePlayer1.ToString();
        scorePlayer2.text = GameManager._GAME_MANAGER.GetScorePlayer2.ToString();
    }

    public GameObject GetLoseUI { get => loseUI; }
    public TimerUI GetTimerUI { get => timerUI; }
    public GameObject GetWinUI { get => winUI; }
}
