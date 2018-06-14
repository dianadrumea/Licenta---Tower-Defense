using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        instance = this;
    }

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Tile tile)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("not enough money to build!");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;
        Debug.Log(" money left:" + PlayerStats.money);

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, tile.GetBuildPosition(), Quaternion.identity);
        tile.turret = turret;
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
