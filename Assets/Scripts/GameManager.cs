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

    private void OnEnable()
    {
        EventManager.OnGameStart += StartGame;
        EventManager.OnGameOver += GameOver;
    }
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

    private void OnDisable()
    {
        EventManager.OnGameStart -= StartGame;
        EventManager.OnGameOver -= GameOver;
    }

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.LogError("EnemySpawner not found in the scene!");
        }
        gameState = GameState.GAME;
        enemySpawner.enabled = true;
        player.enabled = true;
        EventManager.Start();
    }

    public void StartGame()
    {

    }

    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            gameState = GameState.PAUSE;
        }
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