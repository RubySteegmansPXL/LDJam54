using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public GameObject standartTurretToBuild;

    void Start()
    {
        turretToBuild = standartTurretToBuild;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
