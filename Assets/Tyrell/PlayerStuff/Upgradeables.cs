using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeables : MonoBehaviour
{
    #region singleton
    public static Upgradeables instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    #region KeepsTrackOfUpgrades

    //upgrade Analytics values
    [HideInInspector] public int NumberOfUpgrades = 0;
    [HideInInspector] public int ProSpeedUpgraded = 0;
    [HideInInspector] public int ProDamageUpgraded = 0;
    [HideInInspector] public int FireRateUpgraded = 0;
    [HideInInspector] public int ProjectilesNumUpgraded = 0;
    [HideInInspector] public int projectileSizeUpgraded = 0;
    [HideInInspector] public int PierceUpgraded = 0;
    [HideInInspector] public int CritChanceUpgraded = 0;
    [HideInInspector] public int RicochetUpgraded = 0;
    [HideInInspector] public int ExplosionUpgraded = 0;
    [HideInInspector] public int FreezeUpgraded = 0;
    [HideInInspector] public int SpreadUpgraded = 0;

    #endregion


    #region SetBonus

    [Header("SetBonuses")]
    //Set bonuses
    [HideInInspector] public bool ArmorPiercer;
    [HideInInspector] public bool MegaRicochet;
    [HideInInspector] public bool ExplosionMagnet;
    [HideInInspector] public bool Seeking;
    [HideInInspector] public bool LifeSteal;
    [HideInInspector] public bool UltraFreeze;

    #endregion


    //gets the highest used upgrade the player is using
    [HideInInspector] public string UpgradeUsedMost;
    [HideInInspector] public int MostUsedUpgrade;

    #region UpgradeValues

    //upgrade values
    [Header("Upgrade values")]
    public float projectileSpeed = 700;

    public int projectileDamage = 10;
    public int projectileBaseDamage = 10;

    public float critChance = 0;

    public float _fireRate = 1;

    public float _nextFire;

    public int NumberOfProjectile = 1;

    public Vector3 ProjectileSize = new Vector3(0.5f, 0.5f, 0.5f);

    public float ProjectileLifeTime = 5;

    public float PierceCountUpgraded = 0;

    public bool Ricochet = false;
    public int ricochetCountUpgraded = 0;

    public float ExplosionArea = 0;
    public int explosiveCountUpgraded = 0;

    public float FreezeTime = 0;

    public float SpreadFactor = 15;

    #endregion

    #region PlayerValues

    //Player values

    [Header("Player values")]
    public float Health = 100;
    public float MaxHealth = 100;
    public float sliderHealthVal;

    public float playerSpeed = 15;

    public float _dashSpeed = 40f;
    public float _dashTime = 0.25f;
    public float _dashCooldownTime = 3;

    public float ItemDropChance = 10;
    public int dropchanceincrease = 100; 

    #endregion



    //scripts
    [Header("Script Refrences")]
    public GunInventoryController gunInventoryController;
    public MoneyManager moneyManager;
    public PlayerHealth pHealth;

    private void Start()
    {
        gunInventoryController = FindObjectOfType<GunInventoryController>(transform);
    }

    private void Update()
    {
        sliderHealthVal = CalculateHealth();
        if (FireRateUpgraded == 0)
            _fireRate = 1;
    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }


    #region GunUpgrades


    //*------- Gun Upgrades --------*//

    //Projectile speed upgrade
    public void UpgradeProjectileSpeed(float amount, float upgradeamount)
    {
        ProSpeedUpgraded++;
        projectileSpeed += amount;

        //projectileDamage = Mathf.RoundToInt(projectileDamage * upgradeamount);
        //projectileBaseDamage = Mathf.RoundToInt(projectileBaseDamage * upgradeamount);
    }
    public void RemoveUpgradeProjectileSpeed(float amount, float upgradeamount)
    {
        ProSpeedUpgraded--;
        projectileSpeed -= amount;
    }

    //Projectile Damage upgrade
    public void UpgradeProjectileDamage(float amount, float upgradeAmount)
    {
        ProDamageUpgraded++;
        projectileDamage = Mathf.RoundToInt(projectileDamage * (amount + upgradeAmount));
        projectileBaseDamage = Mathf.RoundToInt(projectileBaseDamage * (amount + upgradeAmount));

    }
    public void RemoveUpgradeProjectileDamage(float amount, float upgradeAmount)
    {
        ProDamageUpgraded--;
        projectileDamage = Mathf.RoundToInt(projectileDamage / (amount + upgradeAmount));
        projectileBaseDamage = Mathf.RoundToInt(projectileBaseDamage / (amount + upgradeAmount));
    }

    //Fire Rate upgrades
    public void UpgradeFireRate(float amount, float upgradeAmount)
    {

        _fireRate = _fireRate / (amount + upgradeAmount);
        FireRateUpgraded++;
    }
    public void RemoveUpgradeFireRate(float amount, float upgradeAmount)
    {
        _fireRate = _fireRate * (amount + upgradeAmount);
        FireRateUpgraded--;

    }

    //increase amount of Projectiles upgrade
    public void UpgradeNumOfProjectiles(float amount)
    {
        ProjectilesNumUpgraded++;
        NumberOfProjectile += (int)amount;
    }
    public void RemoveUpgradeNumOfProjectiles(float amount)
    {
        ProjectilesNumUpgraded--;
        NumberOfProjectile -= (int)amount;
    }

    //ProjectileSize upgrades
    public void UpgradeProjectileSize(float amount)
    {
        projectileSizeUpgraded++;
        ProjectileSize += new Vector3(amount, amount, amount);
    }
    public void RemoveProjectileSize(float amount)
    {
        projectileSizeUpgraded--;
        ProjectileSize -= new Vector3(amount, amount, amount);
    }

    //Upgrade Pierce
    public void UpgradePierceCount(float amount)
    {
        PierceUpgraded++;
        PierceCountUpgraded += amount;
    }
    public void RemovePierceCount(float amount)
    {
        PierceUpgraded--;
        PierceCountUpgraded -= amount;
    }


    //Crit Chance
    public void UpgradeCritChance(float amount)
    {

        if (CritChanceUpgraded <= 4)
            critChance += amount;

        CritChanceUpgraded++;
    }
    public void RemoveCritChance(float amount)
    {

        if (CritChanceUpgraded <= 5)
            critChance -= amount;

        CritChanceUpgraded--;
    }

    //Ricochet
    public void UpgradeRicochet(float amount)
    {
        RicochetUpgraded++;
        Ricochet = true;
        ricochetCountUpgraded += (int)amount;
    }
    public void RemoveRicochet(float amount)
    {
        RicochetUpgraded--;
        Ricochet = false;
        ricochetCountUpgraded -= (int)amount;
    }

    //Impact Explosion
    public void UpgradeImpactExpolosion(float amount, float upgradeamount)
    {
        ExplosionUpgraded++;
        ExplosionArea++;
        ExplosionArea = ExplosionArea * (amount + upgradeamount);
        explosiveCountUpgraded++;
    }
    public void RemoveImpactExplosion(float amount, float upgradeamount)
    {
        ExplosionUpgraded--;
        
        ExplosionArea = ExplosionArea / (amount + upgradeamount);
        ExplosionArea--;
        explosiveCountUpgraded--;
    }

    //freeze
    public void UpgradeFreezeProjectiles(float amount)
    {
        FreezeTime += amount;
        FreezeUpgraded++;
    }
    public void RemoveFreezeProjectiles(float amount)
    {
        FreezeTime -= amount;
        FreezeUpgraded--;
    }

    //Spread Factor
    public void UpgradesSpreadFactor(float amount)
    {
        SpreadUpgraded++;
        SpreadFactor += amount;
    }
    public void RemoveSpreadFactor(float amount)
    {
        SpreadUpgraded--;
        SpreadFactor -= amount;
    }


    //*------- Gun Upgrades --------*//


    #endregion

    #region PlayerUpgrades

    //*------- Player upgrades --------*//

    //Gun Inventory
    public void UpgradeGunInventory()
    {
        gunInventoryController.AddGunInventorySlot();
    }


    //MaxHealth
    public void UpgradeMaxHealth(float amount)
    {
        MaxHealth += amount;
    }

    //Heal
    public void HealHealth()
    {
        Health = MaxHealth;
    }

    //Speed
    public void UpgradeSpeed(float amount)
    {
        playerSpeed = playerSpeed * amount;
    }

    //money Gain
    public void UpgradeMoney(float amount)
    {
        moneyManager.IncreaseMoney(amount);
    }

    //Give Random Item
    public void RandomItem()
    {
        Item newItem = GameManager.instance.GunItemList[Random.Range(0, GameManager.instance.GunItemList.Count)];

        Inventory.instance.AddItem(Instantiate(newItem));
    }

    //Dash Cooldown
    public void DashCooldown(float amount)
    {
        _dashCooldownTime -= amount;
    }

    //*------- Player upgrades --------*// 
    #endregion


}
