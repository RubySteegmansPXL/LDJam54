using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerTile : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;
    private Renderer rend;
    private BuildManager buildManager;

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (buildManager.towerCount >= GameManager.instance.player.TilesUnlocked) return;
        if(!buildManager.CanBuild) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (turret != null)
        {
            return;
        }
        BuildTower();
    }

    private void BuildTower()
    {
        TurretBlueprint print = buildManager.GetTurretToBuild();
        if (print == null) { Debug.Log("no turret available"); }
        turret = Instantiate(print.prefab, transform.position + positionOffset, transform.rotation);
        buildManager.towerCount++;
        buildManager.SelectTurretToBuild(null);
        GameManager.instance.player.Buy(print.cost);
    }
    private void OnMouseEnter()
    {
        if (buildManager.towerCount >= GameManager.instance.player.TilesUnlocked) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        rend.enabled = true;
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.enabled = false;
    }
}
