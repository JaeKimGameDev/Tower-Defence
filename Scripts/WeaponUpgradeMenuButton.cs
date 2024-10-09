using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeMenuButton : MonoBehaviour
{

    public GameObject heroButton;
    public GameObject weaponsButton;
    public GameObject handgunUpgradeButton;
    public GameObject assaultRifleUpgradeButton;
    public GameObject sniperRifleUpgradeButton;
    public GameObject backButton;

    public GameObject HandGunUpgrade;
    public GameObject HeroHandGunUpgrade;
    public GameObject AssaultUpgrade;
    public GameObject HeroAssaultUpgrade;
    public GameObject SniperUpgrade;
    public GameObject HeroSniperUpgrade;

    public GameObject manager;
    public BuildManager buildManager;

    private void Start()
    {
        buildManager = manager.GetComponent<BuildManager>();
    }

    public void UpgradeWeapons()
    {
        heroButton.SetActive(false);
        weaponsButton.SetActive(false);
        handgunUpgradeButton.SetActive(true);
        assaultRifleUpgradeButton.SetActive(true);
        sniperRifleUpgradeButton.SetActive(true);
        backButton.SetActive(true);
    }
    public void BackFromWeapons()
    {
        heroButton.SetActive(true);
        weaponsButton.SetActive(true);
        handgunUpgradeButton.SetActive(false);
        assaultRifleUpgradeButton.SetActive(false);
        sniperRifleUpgradeButton.SetActive(false);
        backButton.SetActive(false);
    }
    public void UpgradeHandGun()
    {
        HandGunUpgrade.GetComponent<Defender>().IncreaseGunDamage(3f);
        HeroHandGunUpgrade.GetComponent<Defender>().IncreaseGunDamage(5f);
        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "HGDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(3f);
            }
            else if (defender.tag == "HGHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(5f);
            }
        }
    }
    public void UpgradeAssaultRifle()
    {
        AssaultUpgrade.GetComponent<Defender>().IncreaseGunDamage(4f);
        HeroAssaultUpgrade.GetComponent<Defender>().IncreaseGunDamage(7f);

        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "ARDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(4f);
            }
            else if (defender.tag == "ARHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(7f);
            }
        }
    }
    public void UpgradeSniperRifle()
    {
        SniperUpgrade.GetComponent<Defender>().IncreaseGunDamage(16f);
        HeroSniperUpgrade.GetComponent<Defender>().IncreaseGunDamage(26f);

        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "SGDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(16f);
            }
            else if (defender.tag == "SGHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(26f);
            }
        }
    }
}
