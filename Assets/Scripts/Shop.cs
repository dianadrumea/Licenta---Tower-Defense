using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectedTurret()
    {
        buildManager.SetTurretToBuild(buildManager.turretPrefab);
    }

    public void SelectedMissileLauncher()
    {
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
