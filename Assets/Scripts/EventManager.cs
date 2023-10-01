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
    public static event Action<int> OnWaveCompleted;
    public static event Action<GameState> OnGameStateChanged;

    public void GameStateChanged(GameState state)
    {
        if (OnGameStateChanged != null)
        {
            OnGameStateChanged?.Invoke(state);
        }
    }

    public void WaveCompleted(int score)
    {
        if(OnWaveCompleted != null)
        {
            OnWaveCompleted?.Invoke(score);
        }
    }

    public static void Start()
    {
        OnGameStart?.Invoke();
    }
}