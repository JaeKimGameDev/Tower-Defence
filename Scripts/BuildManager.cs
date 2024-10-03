using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    public List<GameObject> allNormalDefenders = new List<GameObject>();
    public List<GameObject> allHeroDefenders = new List<GameObject>();
    private GameObject spawnDefender;
    public bool buildHero;

    public PlayerAttributes playerAttributes;
    public TextMeshProUGUI heroButtonText;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    
    public GameObject GetNormalDefenderToBuild()
    {
        if (playerAttributes.playerResource >= 1)
        {
            playerAttributes.DecrementPlayerResource(1);
            int defender = Random.Range(0, allNormalDefenders.Count);
            spawnDefender = allNormalDefenders[defender];

            return spawnDefender;
        }
        else
        {
            Debug.Log("you require more resources");
            return null;
        }
    }

    public GameObject GetHeroDefenderToBuild()
    {
        if (playerAttributes.playerResource >= 1)
        {
            playerAttributes.DecrementPlayerResource(1);
            int defender = Random.Range(0, allHeroDefenders.Count);
            spawnDefender = allHeroDefenders[defender];
            DisableHero();
            return spawnDefender;
        }
        else
        {
            Debug.Log("you require more resources");
            return null;
        }
    }

    public bool BuildID()
    {
        if (buildHero == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void EnableHero()
    {
        if (playerAttributes.playerResource >= 1 & buildHero == false)
        {
            playerAttributes.DecrementPlayerResource(1);
            buildHero = true;
            heroButtonText.GetComponent<TextMeshProUGUI>().color = new Color32(60, 110, 34, 255);
        }
        else if (buildHero == true)
        {
            Debug.Log("you already enabled Hero to be built next");
        }
        else
        {
            Debug.Log("you require more resources");
        }
    }

    public void DisableHero()
    {
        heroButtonText.GetComponent<TextMeshProUGUI>().color = new Color32(107, 3, 73, 255);
        buildHero = false;
    }
}
