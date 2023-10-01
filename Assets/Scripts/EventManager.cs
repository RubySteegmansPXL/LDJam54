using System;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [System.Serializable] public class EventGameState : UnityEvent<bool> { }

    public static EventManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static event Action OnGameStart;
    public static event Action OnWaveCompleted;
    public static event Action OnMoneyGained;
    public static event Action OnItemBought;
    public static event Action OnDamageTaken;
    public static event Action OnTowerPlaced;
    public static event Action<GameState> OnGameStateChanged;

    public void GameStateChanged(GameState state)
    {
        if (OnGameStateChanged != null)
        {
            OnGameStateChanged?.Invoke(state);
        }
        if(state == GameState.GAMEOVER)
        {
            GameManager.instance.GameOver();
        }
    }

    public void WaveCompleted()
    {
        if(OnWaveCompleted != null)
        {
            OnWaveCompleted?.Invoke();
        }
    }

    public static void Start()
    {
        OnGameStart?.Invoke();
    }

    public static void MoneyGained()
    {
        OnMoneyGained?.Invoke();
    }

    public static void ItemBought()
    {
        OnItemBought?.Invoke();
    }

    public static void DamageTaken()
    {
        OnDamageTaken?.Invoke();
    }
    public static void TowerPlaced()
    {
        OnTowerPlaced?.Invoke();
    }
}