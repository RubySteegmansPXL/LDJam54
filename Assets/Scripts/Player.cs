using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Money;
    private int startMoney = 175;

    public int Lives;
    private int startLives = 20;

    public int TilesUnlocked;
    private int startTiles = 1;

    public int score = 0;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        TilesUnlocked = startTiles;

        score = 0;
    }

    private void OnEnable()
    {
        EventManager.OnWaveCompleted += AddScore;
    }

    private void OnDisable()
    {
        EventManager.OnWaveCompleted -= AddScore;
    }

    private void AddScore(int Score)
    {
        score += Score;
    }

    public void TakeDamage(int dmg)
    {
        Lives -= dmg;

        if(Lives <= 0)
        {
            EventManager.instance.GameStateChanged(GameState.GAMEOVER);
        }
    }
}
