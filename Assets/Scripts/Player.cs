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
    public int MaxTiles = 5;

    public int score = 0;
    public Menu menu;

    void Awake()
    {
        Money = startMoney;
        Lives = startLives;
        TilesUnlocked = startTiles;

        score = 0;
    }

    public void Reset()
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
    public void AddMoney(int money)
    {
        Money += money;
        EventManager.MoneyGained();
    }

    private void AddScore()
    {
        score++;
        if(score == 5)
        {
            menu.Thanks();
        }
    }

    public void TakeDamage(int dmg)
    {
        Lives -= dmg;

        if(Lives <= 0)
        {
            EventManager.instance.GameStateChanged(GameState.GAMEOVER);
            return;
        }

        EventManager.DamageTaken();
    }

    public void Buy(int cost)
    {
        Money -= cost;
        EventManager.ItemBought();
    }

    public void BuyTile()
    {
        TilesUnlocked++;
    }
}
