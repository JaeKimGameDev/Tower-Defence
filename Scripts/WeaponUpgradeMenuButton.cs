using TMPro;
using UnityEngine;

public class WeaponUpgradeMenuButton : MonoBehaviour
{
    public GameObject heroButton;
    public GameObject weaponsButton;

    public GameObject HandGunUpgrade;
    public GameObject HeroHandGunUpgrade;
    public GameObject AssaultUpgrade;
    public GameObject HeroAssaultUpgrade;
    public GameObject SniperUpgrade;
    public GameObject HeroSniperUpgrade;
    public GameObject ShotGunUpgrade;
    public GameObject HeroShotGunUpgrade;

    public GameObject manager;
    public BuildManager buildManager;

    public int weaponUpgradeCost;
    public PlayerAttributes playerAttributes;
    public TextMeshProUGUI upgradeWeaponText;
    public float normalHandGunUpgrade, heroHandGunUpgrade;
    public float normalAssaultUpgrade, HeroHandAssaultUpgrade;
    public float normalSniperUpgrade, heroSniperUpgrade;
    public float normalShotgunUpgrade, heroShotgunUpgrade;

    private void Start()
    {
        upgradeWeaponText.text = "Upgrade Weapons\n+" + weaponUpgradeCost.ToString() + " Resource";
        buildManager = manager.GetComponent<BuildManager>();
    }
    public void UpgradeHandGun()
    {
        HandGunUpgrade.GetComponent<Defender>().IncreaseGunDamage(normalHandGunUpgrade);
        HeroHandGunUpgrade.GetComponent<Defender>().IncreaseGunDamage(heroHandGunUpgrade);
        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "HGDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(normalHandGunUpgrade);
            }
            else if (defender.tag == "HGHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(heroHandGunUpgrade);
            }
        }
    }
    public void UpgradeAssaultRifle()
    {
        AssaultUpgrade.GetComponent<Defender>().IncreaseGunDamage(normalAssaultUpgrade);
        HeroAssaultUpgrade.GetComponent<Defender>().IncreaseGunDamage(HeroHandAssaultUpgrade);

        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "ARDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(normalAssaultUpgrade);
            }
            else if (defender.tag == "ARHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(HeroHandAssaultUpgrade);
            }
        }
    }
    public void UpgradeSniperRifle()
    {
        SniperUpgrade.GetComponent<Defender>().IncreaseGunDamage(normalSniperUpgrade);
        HeroSniperUpgrade.GetComponent<Defender>().IncreaseGunDamage(heroSniperUpgrade);

        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "SGDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(normalSniperUpgrade);
            }
            else if (defender.tag == "SGHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(heroSniperUpgrade);
            }
        }
    }
    public void UpgradeShotgun()
    {
        ShotGunUpgrade.GetComponent<Defender>().IncreaseGunDamage(normalShotgunUpgrade);
        HeroShotGunUpgrade.GetComponent<Defender>().IncreaseGunDamage(heroShotgunUpgrade);

        foreach (GameObject defender in buildManager.SpawnedDefenders)
        {
            if (defender.tag == "ShotGunDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(normalShotgunUpgrade);
            }
            else if (defender.tag == "ShotGunHeroDefender")
            {
                defender.GetComponent<Defender>().IncreaseGunDamage(heroShotgunUpgrade);
            }
        }
    }
    public void CheckResourcesForUpgradeWeapon()
    {
        if (playerAttributes.GetComponent<PlayerAttributes>().playerResource >= weaponUpgradeCost)
        {
            playerAttributes.DecrementPlayerResource(weaponUpgradeCost);
            weaponUpgradeCost++;
            upgradeWeaponText.text = "Upgrade Weapons\n+" + weaponUpgradeCost.ToString() + " Resource";
            UpgradeHandGun();
            UpgradeAssaultRifle();
            UpgradeSniperRifle();
            UpgradeShotgun();
        }
        else
        {
            Debug.Log("Require more resources");
        }
    }
}
