using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;
    public TurretBlueprint turret;
    public TurretBlueprint missileLauncher;

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
}
