using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;


    private TurretBlueprint turretToBuild;
    public int currentTurrets = 0;
    private int turretLimit = 1;

    public int TurretLimit
    {
        set { turretLimit = value;}
    }

    public bool CanBuild { get { return turretToBuild != null || currentTurrets >= turretLimit; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
