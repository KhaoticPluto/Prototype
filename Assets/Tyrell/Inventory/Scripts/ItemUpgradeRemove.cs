using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgradeRemove : MonoBehaviour
{
    #region singleton
    public static ItemUpgradeRemove instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public int NumberOfUpgrades;
    public Upgradeables upgrade;

    private void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            upgrade = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
            Debug.Log("ItemUpgrade found " + upgrade);
        }

    }

    public void OnStatItemUse(ItemType itemType, float amount)
    {
        NumberOfUpgrades++;
        upgrade.GetComponent<Upgradeables>();
        Debug.Log("Upgrade " + itemType + " by " + amount);
        switch (itemType)
        {
            case ItemType.FireRate:
                upgrade.UpgradeFireRate(amount);
                break;

            case ItemType.Damage:
                upgrade.UpgradeProjectileDamage(amount);
                break;

            case ItemType.ProjectileSpeed:
                upgrade.UpgradeProjectileSpeed(amount);
                break;

            case ItemType.NumOfProjectiles:
                upgrade.UpgradeNumOfProjectiles(amount);
                break;

            case ItemType.ProjectileSize:
                upgrade.UpgradeProjectileSize(amount);
                break;

            case ItemType.ProjectilePierce:
                upgrade.UpgradePierceCount(amount);
                break;

            case ItemType.CritChance:
                upgrade.UpgradeCritChance(amount);
                break;

            case ItemType.Ricochet:
                upgrade.UpgradeRicochet(amount);
                break;

            case ItemType.ImpactExplosion:
                upgrade.UpgradeImpactExpolosion(amount);
                break;

            case ItemType.Freeze:
                upgrade.UpgradeFreezeProjectiles(amount);
                break;

            case ItemType.IncreaseSpread:
                upgrade.UpgradesSpreadFactor(amount);
                break;
        }
    }

    public void OnStatItemRemove(ItemType itemType, float amount)
    {
        NumberOfUpgrades--;
        upgrade.GetComponent<Upgradeables>();
        Debug.Log("Remove " + itemType + " by " + amount);
        switch (itemType)
        {
            case ItemType.FireRate:
                upgrade.RemoveUpgradeFireRate(amount);
                break;

            case ItemType.Damage:
                upgrade.RemoveUpgradeProjectileDamage(amount);
                break;

            case ItemType.ProjectileSpeed:
                upgrade.RemoveUpgradeProjectileSpeed(amount);
                break;

            case ItemType.NumOfProjectiles:
                upgrade.RemoveUpgradeNumOfProjectiles(amount);
                break;

            case ItemType.ProjectileSize:
                upgrade.RemoveProjectileSize(amount);
                break;

            case ItemType.ProjectilePierce:
                upgrade.RemovePierceCount(amount);
                break;

            case ItemType.CritChance:
                upgrade.RemoveCritChance(amount);
                break;

            case ItemType.Ricochet:
                upgrade.RemoveRicochet(amount);
                break;

            case ItemType.ImpactExplosion:
                upgrade.RemoveImpactExplosion(amount);
                break;

            case ItemType.Freeze:
                upgrade.RemoveFreezeProjectiles(amount);
                break;

            case ItemType.IncreaseSpread:
                upgrade.RemoveSpreadFactor(amount);
                break;
        }
    }
}
