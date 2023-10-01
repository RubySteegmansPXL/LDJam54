using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    
    public GameState gameState;
    private EnemySpawner enemySpawner;
    public Player player;

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

    private void Start()
    {
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public void StartGame()
    {
        gameState = GameState.GAME;
        enemySpawner.enabled = true;
        EventManager.Start();
    }

    public void PauseGame()
    {
        gameState = GameState.PAUSE;
    }

    public void ResumeGame()
    {
        gameState = GameState.GAME;
    }

    public void GameOver()
    {
        gameState = GameState.GAMEOVER;
    }

    public void MainMenu()
    {
        gameState = GameState.MENU;
    }
}

public enum GameState
{
    GAMEOVER,
    GAME,
    MENU,
    PAUSE
}