using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    
    public GameState gameState;
    private EnemySpawner enemySpawner;
    public Player player;
    public GameObject gameOverMenu;
    public Text gameOverText;

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
        enemySpawner.enabled = false;

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }

        gameOverMenu.SetActive(true);
        gameOverText.text = "Oops, you died... You made it to wave: " + player.score;
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