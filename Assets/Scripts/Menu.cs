using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button backButton;
    public Button back2Button;    
    public GameObject gameOverMenu;
    public GameObject thankYouMenu;
    public UIhandler uiHandler;
    public GameObject shop;
    public GameObject statsUI;

    private void Start()
    {
        backButton.onClick.AddListener(BackButtonClicked);
        back2Button.onClick.AddListener(BackButtonClicked);
    }

    private void BackButtonClicked()
    {
        ScreenFader.instance.FadeTo("MainMenu");
    }

    private void StartButtonClicked()
    {
        statsUI.SetActive(true);
        shop.SetActive(true);
        uiHandler.enabled = true;
        EventManager.Start();
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }
    public void CloseShop()
    {
        shop.SetActive(false);
    }

    public void Thanks()
    {
        thankYouMenu.SetActive(true);
        statsUI.SetActive(false);
        shop.SetActive(false);
    }
    private void GameOver()
    {
        gameOverMenu.SetActive(true);
        statsUI.SetActive(false);
        shop.SetActive(false);
    }

}
