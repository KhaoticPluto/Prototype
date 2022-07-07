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
        upgrade.GetComponent<Upgradeables>();
        Debug.Log("Upgrade" + itemType + " by " + amount);
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
                upgrade.UpgradeRicochet();
                break;
        }
    }

    public void OnStatItemRemove(ItemType itemType, float amount)
    {
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
                upgrade.RemoveRicochet();
                break;

        }
    }
}