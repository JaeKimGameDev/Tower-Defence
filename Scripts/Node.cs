using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;
    private GameObject turret;

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO display on screen");
            // or play an audio saying "I can't build there"
            return;
        }
        // build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
}
