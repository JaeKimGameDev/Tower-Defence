using TMPro;
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

    public int weaponUpgradeCost;
    public PlayerAttributes playerAttributes;
    public TextMeshProUGUI upgradeWeaponText;

    private void Start()
    {
        upgradeWeaponText.text = "Upgrade Weapons\n" + weaponUpgradeCost.ToString() + " Resource";
        buildManager = manager.GetComponent<BuildManager>();
    }
    public void UpgradeHandGun()
    {
        HandGunUpgrade.GetComponent<Defender>().IncreaseGunDamage(1f);
        HeroHandGunUpgrade.GetComponent<Defender>().IncreaseGunDamage(2f);
        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "HGDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(1f);
            }
            else if (defender.tag == "HGHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(2f);
            }
        }
    }
    public void UpgradeAssaultRifle()
    {
        AssaultUpgrade.GetComponent<Defender>().IncreaseGunDamage(2f);
        HeroAssaultUpgrade.GetComponent<Defender>().IncreaseGunDamage(3f);

        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "ARDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(2f);
            }
            else if (defender.tag == "ARHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(3f);
            }
        }
    }
    public void UpgradeSniperRifle()
    {
        SniperUpgrade.GetComponent<Defender>().IncreaseGunDamage(2f);
        HeroSniperUpgrade.GetComponent<Defender>().IncreaseGunDamage(3f);

        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "SGDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(2f);
            }
            else if (defender.tag == "SGHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(3f);
            }
        }
    }
    public void CheckResourcesForUpgradeWeapon()
    {
        if (playerAttributes.GetComponent<PlayerAttributes>().playerResource >= weaponUpgradeCost)
        {
            playerAttributes.DecrementPlayerResource(weaponUpgradeCost);
            weaponUpgradeCost++;
            upgradeWeaponText.text = "Upgrade Weapons\n" + weaponUpgradeCost.ToString() + " Resource";
            UpgradeHandGun();
            UpgradeAssaultRifle();
            UpgradeSniperRifle();
        }
        else
        {
            Debug.Log("Require more resources");
        }
    }
}
