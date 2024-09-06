using UnityEngine;

public class Node : MonoBehaviour
{
    private Color startColor;
    public Color hoverColor;
    public Color unableHoverColor;
    private Renderer rend;
    public Vector3 positionOffset;
    private GameObject turret;

    void Start()
    {
        // used to get original color of node
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO display on screen");
            return;
        }
        // build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    // mouse hits the node, change color
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        if (turret != null)
        {
            rend.material.color = unableHoverColor;
        }
    }

    // mouse exits node, change color back to original
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
