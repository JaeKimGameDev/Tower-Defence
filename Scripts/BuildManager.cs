using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    //public GameObject orangeDefenderPrefab;
    //public GameObject yellowDefenderPrefab;
    //public GameObject redDefenderPrefab;
    //private GameObject randomDefender;
    //public GameObject defenderToBuild;
    
    public List<GameObject> allDefenders = new List<GameObject>();
    public List<GameObject> spawnDefenders;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    
    public List<GameObject> GetDefenderToBuild()
    {
        spawnDefenders = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            int defender = Random.Range(0, allDefenders.Count);
            spawnDefenders.Add(allDefenders[defender]);
        }

        return spawnDefenders;
    }
    //public GameObject GetHeroToBuild()
    //{

    //    return randomDefender;
    //}
}
