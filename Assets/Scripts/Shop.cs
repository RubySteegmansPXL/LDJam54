using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint turtle;
    private int[] tileCosts = new int[]{ 500, 1000, 2000, 4000};

    BuildManager buildManager;
    public Button tileButton;
    public Button turtleButton;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void Update()
    {
        int currentMoney = GameManager.instance.player.Money;
        int tilesUnlocked = GameManager.instance.player.TilesUnlocked;
        if (currentMoney < tileCosts[tilesUnlocked - 1] || tilesUnlocked == GameManager.instance.player.MaxTiles)
        {
            tileButton.enabled = false;
        } else
        {
            tileButton.enabled = true;
        }
        if(currentMoney < turtle.cost){
            turtleButton.enabled = false;
        } else
        {
            turtleButton.enabled = true;
        }
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(turtle);
    }

    public void UnlockExtraTile()
    {
        Debug.Log("Tile unlocked!");
        int tilesUnlocked = GameManager.instance.player.TilesUnlocked;
        GameManager.instance.player.Buy(tileCosts[tilesUnlocked - 1]);
        GameManager.instance.player.BuyTile();

    }
}
