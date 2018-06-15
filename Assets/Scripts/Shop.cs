using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;
    public TurretBlueprint turret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laser;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectedTurret()
    {
        buildManager.SetTurretToBuild(turret);
    }

    public void SelectedMissileLauncher()
    {
        buildManager.SetTurretToBuild(missileLauncher);
    }

    public void SelectedLaser()
    {
        buildManager.SetTurretToBuild(laser);
    }
}
