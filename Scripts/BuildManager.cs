using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject orangeTurretPrefab;
    public GameObject yellowTurretPrefab;
    public GameObject redTurretPrefab;
    public GameObject turretToBuild;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
