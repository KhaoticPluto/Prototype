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

    //General
    string WavesCompleted = "Waves Completed";
    string UpgradesUsed = "Upgrades Used";
    string ItemsPurchased = "Items Brought";
    
    //Upgrades
    string ProSpeedUpgraded = "ProSpeed Upgraded";
    string ProDamageUpgraded = "ProDamage Upgraded";
    string FireRateUpgraded = "FireRate Upgraded";
    string ProjectilesNumUpgraded = "ProjectilesNum Upgraded";
    string projectileSizeUpgraded = "ProjectilSize Upgraded";
    string PierceUpgraded = "Pierce Upgraded";
    string CritChanceUpgraded = "CritChance Upgraded";
    string RicochetUpgraded = "Ricochet Upgraded";
    string ExplosionUpgraded = "Explosion Upgraded";

    //Player
    string PlayerMoved = "Player Has Moved";
    string PlayerStill = "Player Is Still";

    //Game states
    string GameStarted = "Game Started";
    string GameQuit = "Game Quit";
    string GameCompleted = "Game Complete";

    public void SendAnalytics()
    {
        GameAnalytics.NewDesignEvent(WavesCompleted, GameManager.instance.WavesCompleted);
        GameAnalytics.NewDesignEvent(UpgradesUsed, ItemUpgradeRemove.instance.NumberOfUpgrades);
        GameAnalytics.NewDesignEvent(ItemsPurchased, PlayerItemUpgradeRemove.instance.NumberOfPurchases);


        //upgrades Used Analytics
        GameAnalytics.NewDesignEvent(ProSpeedUpgraded, Upgradeables.instance.ProSpeedUpgraded);
        GameAnalytics.NewDesignEvent(ProDamageUpgraded, Upgradeables.instance.ProDamageUpgraded);
        GameAnalytics.NewDesignEvent(FireRateUpgraded, Upgradeables.instance.FireRateUpgraded);
        GameAnalytics.NewDesignEvent(ProjectilesNumUpgraded, Upgradeables.instance.ProjectilesNumUpgraded);
        GameAnalytics.NewDesignEvent(projectileSizeUpgraded, Upgradeables.instance.projectileSizeUpgraded);
        GameAnalytics.NewDesignEvent(PierceUpgraded, Upgradeables.instance.PierceUpgraded);
        GameAnalytics.NewDesignEvent(CritChanceUpgraded, Upgradeables.instance.CritChanceUpgraded);
        GameAnalytics.NewDesignEvent(RicochetUpgraded, Upgradeables.instance.RicochetUpgraded);
        GameAnalytics.NewDesignEvent(ExplosionUpgraded, Upgradeables.instance.ExplosionUpgraded);

        //player Movement
        GameAnalytics.NewDesignEvent(PlayerMoved, movement.instance.HowMuchPlayerMoved);
        GameAnalytics.NewDesignEvent(PlayerStill, movement.instance.HowMuchPlayerStill);

    }

    public void GameStartAnalytics()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, GameStarted);
        
    }

    public void GameCompletedAnalytics()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, GameCompleted, GameManager.instance.WavesCompleted);
    }

    public void GameQuitAnalytics()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, GameQuit, GameManager.instance.WavesCompleted);

    }

}
