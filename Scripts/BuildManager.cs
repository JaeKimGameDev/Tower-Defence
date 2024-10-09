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

    public GameObject heroMenuButton;
    public GameObject recruitMenuButton;

    public List<GameObject> SpawnedDefenders = new List<GameObject>();

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
        if (playerAttributes.playerResource >= 2)
        {
            playerAttributes.DecrementPlayerResource(2);
            int defender = Random.Range(0, allHeroDefenders.Count);
            spawnDefender = allHeroDefenders[defender];

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

    public void HeroButtonClicked()
    {
        if (buildHero == true)
        {
            heroMenuButton.SetActive(false);
            recruitMenuButton.SetActive(true);
            buildHero = false;
            heroButtonText.text = "Recruits \n+1 Resources";
        }
        else
        {
            heroMenuButton.SetActive(true);
            recruitMenuButton.SetActive(false);
            buildHero = true;
            heroButtonText.text = "Heros \n+2 Resources";
        }
    }
}
