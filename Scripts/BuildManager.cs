using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private int defender;

    public bool testMode;
    [SerializeField] private int defenderTest;

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
            int defenderNumber = Random.Range(0, 20);
            int resourceBonus = Random.Range(0, 25);
            if (resourceBonus == 24)
            {
                playerAttributes.IncrementPlayerResource(2);
            }
            else if (resourceBonus > 21)
            {
                playerAttributes.IncrementPlayerResource(1);
            }
            if (defenderNumber <= 15)
            {
                defender = 0;
            }
            else if (defenderNumber <= 17)
            {
                defender = 1;
            }
            else if (defenderNumber <= 18)
            {
                defender = 2;
            }
            else
            {
                defender = 3;
            }
            if (testMode is true)
            {
                defender = defenderTest;
            }
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
            int defenderNumber = Random.Range(0, 20);
            int resourceBonus = Random.Range(0, 50);
            if (resourceBonus == 49)
            {
                playerAttributes.IncrementPlayerResource(2);
            }
            else if (resourceBonus > 46)
            {
                playerAttributes.IncrementPlayerResource(1);
            }
            if (defenderNumber <= 15)
            {
                defender = 0;
            }
            else if (defenderNumber <= 17)
            {
                defender = 1;
            }
            else if (defenderNumber <= 18)
            {
                defender = 3;
            }
            else
            {
                defender = 2;
            }
            if (testMode is true)
            {
                defender = defenderTest;
            }
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
            heroButtonText.text = "Special Forces\n+1 Resources";
        }
        else
        {
            heroMenuButton.SetActive(true);
            recruitMenuButton.SetActive(false);
            buildHero = true;
            heroButtonText.text = "Heros\n+2 Resources";
        }
    }
}
