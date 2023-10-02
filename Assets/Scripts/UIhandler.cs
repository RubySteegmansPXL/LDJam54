using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIhandler : MonoBehaviour
{
    public Text moneyCount;
    public Text healthCount;
    public Text waveCount;

    private GameManager gameManager;
    private Player player;
    private void OnEnable()
    {
        EventManager.OnMoneyGained += MoneyChanged;
        EventManager.OnItemBought += MoneyChanged;
        EventManager.OnWaveCompleted += () => Invoke(nameof(WaveCompleted), 0.1f);
        EventManager.OnDamageTaken += TookDamage;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        player = gameManager.player;

        waveCount.text = "" + player.score;
        healthCount.text = "" + player.Lives;
        moneyCount.text = "" + player.Money;
    }
    private void OnDisable()
    {
        EventManager.OnMoneyGained -= MoneyChanged;
        EventManager.OnItemBought -= MoneyChanged;
        EventManager.OnWaveCompleted -= WaveCompleted;
        EventManager.OnDamageTaken -= TookDamage;
    }

    void WaveCompleted()
    {
        waveCount.text = "" + player.score;
    }

    void TookDamage()
    {
        healthCount.text = "" + player.Lives;
    }

    void MoneyChanged()
    {
        moneyCount.text = "" + player.Money;
    }
}
