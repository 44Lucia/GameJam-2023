using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAME_MANAGER;

    [SerializeField] private int scorePlayer1;
    [SerializeField] private int scorePlayer2;

    private void Awake()
    {
        if (_GAME_MANAGER != null && _GAME_MANAGER != this)
        {
            Destroy(_GAME_MANAGER);
        }
        else
        {
            _GAME_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    public void addPointsPlayer1(int value) 
    {
        scorePlayer1 += value;
    }

    public void addPointsPlayer2(int value)
    {
        scorePlayer2 += value;
    }

    public float GetScorePlayer1 => scorePlayer1;

    public float GetScorePlayer2 => scorePlayer2;
}
