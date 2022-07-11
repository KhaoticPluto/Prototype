using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class Analytics : MonoBehaviour
{
    #region singleton
    public static Analytics instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    string WavesCompleted = "Waves Completed";
    string UpgradesUsed = "Upgrades Used";
    string ItemsPurchased = "Items Brought";



    public void SendAnalytics()
    {
        GameAnalytics.NewDesignEvent(WavesCompleted, GameManager.instance.WavesCompleted);
        GameAnalytics.NewDesignEvent(UpgradesUsed, ItemUpgradeRemove.instance.NumberOfUpgrades);
        GameAnalytics.NewDesignEvent(ItemsPurchased, PlayerItemUpgradeRemove.instance.NumberOfPurchases);
        
    }


    
}
