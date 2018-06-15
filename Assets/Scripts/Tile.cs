using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour {

    public Color hoverColor;
    public Color unallowed;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Color originalColor;
    private Renderer rend;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney && turret == null)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = unallowed;
        }   
    }

    void OnMouseExit()
    {
        rend.material.color = originalColor;
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;

        if (turret == null)
        {
            buildManager.BuildTurretOn(this);
            if (!buildManager.HasMoney || turret != null)
            {
                rend.material.color = unallowed;
            }
        } 
    }
}
