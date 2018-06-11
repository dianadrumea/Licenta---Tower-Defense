using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Color hoverColor;
    public Color unallowed;
    private Color originalColor;
    private Renderer rend;

    private GameObject turret;
    public Vector3 positionOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        if (turret == null)
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
        if (turret == null)
        {
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            rend.material.color = unallowed;
        }
    }
}
