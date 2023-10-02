using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button backButton;
    public Button startButton;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public GameObject rulesMenu;
    public GameObject shop;
    public GameObject statsUI;

    private void Start()
    {
        backButton.onClick.AddListener(BackButtonClicked);
        startButton.onClick.AddListener(StartButtonClicked);
    }

    private void BackButtonClicked()
    {
        ScreenFader.instance.FadeTo("MainMenu");
    }

    private void StartButtonClicked()
    {
        rulesMenu.SetActive(false);
        statsUI.SetActive(true);
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }
    public void CloseShop()
    {
        shop.SetActive(false);
    }

}
