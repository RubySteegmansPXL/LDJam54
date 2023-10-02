using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button newGameButton;
    public GameObject rulesMenu;
    public GameObject title;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("No GameManager found in scene!");
        }

        startButton.onClick.AddListener(StartButtonClicked);
        quitButton.onClick.AddListener(QuitButtonClicked);
        newGameButton.onClick.AddListener(NewButtonClicked);

    }

    private void StartButtonClicked()
    {
        rulesMenu.SetActive(true);
        startButton.enabled = false; 
        quitButton.enabled = false;
        title.SetActive(false);
    }

    private void NewButtonClicked()
    {
        ScreenFader.instance.FadeToNextScene();
    }

    private void QuitButtonClicked()
    {
        ScreenFader.instance.Quit();
    }
}
