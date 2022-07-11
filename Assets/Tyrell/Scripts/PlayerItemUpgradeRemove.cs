using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemUpgradeRemove : MonoBehaviour
{
    #region singleton
    public static PlayerItemUpgradeRemove instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public int NumberOfPurchases;

    public Upgradeables upgrade;

    private void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            upgrade = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
            Debug.Log("PlayerItemUpgrade found " + upgrade);
        }

    }

    public void OnStatItemUse(DropItemType itemType, float amount)
    {
        NumberOfPurchases++;
        upgrade.GetComponent<Upgradeables>();
        Debug.Log("Upgrade" + itemType + " by " + amount);
        switch (itemType)
        {
            case DropItemType.ExtraInventorySlot:
                upgrade.UpgradeGunInventory();
                break;
            case DropItemType.MaxHealth:
                upgrade.UpgradeMaxHealth(amount);
                break;
            case DropItemType.HealHealth:
                upgrade.HealHealth();
                break;
            case DropItemType.Speed:
                upgrade.UpgradeSpeed(amount);
                break;
            case DropItemType.RandomItem:
                upgrade.RandomItem();
                break;
            case DropItemType.IncreaseMoneyGain:
                upgrade.UpgradeMoney(amount);
                break;
            case DropItemType.DashCooldown:
                upgrade.DashCooldown(amount);
                break;



        }
    }

   
}
