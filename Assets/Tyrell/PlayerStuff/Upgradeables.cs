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

    [Header("SetBonuses")]
    //Set bonuses
    public bool ArmorPiercer;
    public bool MegaRicochet;
    public bool ExplosionMagnet;
    public bool Seeking;
    public bool LifeSteal;
    public bool UltraFreeze;

    //gets the highest used upgrade the player is using
    [HideInInspector] public string UpgradeUsedMost;
    [HideInInspector] public int MostUsedUpgrade;

    //upgrade values
    [Header("Upgrade values")]
    public float projectileSpeed = 700;

    public float projectileDamage = 1;
    public float BaseDamage = 1;
    public float critChance = 0;

    public float _fireRate = 1;

    public float _nextFire;

    public int NumberOfProjectile = 1;

    public Vector3 ProjectileSize = new Vector3(0.5f,0.5f,0.5f);

    public float ProjectileLifeTime = 5;

    public float PierceCountUpgraded = 0;

    public bool Ricochet = false;
    public int ricochetCountUpgraded = 0;

    public float ExplosionArea = 0;
    public int explosiveCountUpgraded = 0;

    public float FreezeTime = 0;

    public float SpreadFactor = 15;

    //Player values

    [Header("Player values")]
    public float Health = 100;
    public float MaxHealth = 100;


    public float playerSpeed = 15;

    public float _dashSpeed = 40f;
    public float _dashTime = 0.25f;
    public float _dashCooldownTime = 3;

    public float ItemDropChance = 10;
    public int dropchanceincrease = 100;


    //scripts
    [Header("Script Refrences")]
    public GunInventoryController gunInventoryController;
    public MoneyManager moneyManager;
    public PlayerHealth pHealth;

    private void Start()
    {
        gunInventoryController = FindObjectOfType<GunInventoryController>(transform);
    }


    //Reset upgrades if lowered past lowest amount
    private void Update()
    {
        //MostUsedUpgrade = Mathf.Max(ProSpeedUpgraded, ProDamageUpgraded, FireRateUpgraded, ProjectilesNumUpgraded, projectileSizeUpgraded,
        //PierceUpgraded, CritChanceUpgraded, RicochetUpgraded, ExplosionUpgraded);
  


        if (_fireRate <= 0.01f)
        {
            _fireRate = 0.1f;
        }

        if (projectileSpeed >= 160)
        {
            projectileSpeed = 150;
        }

        if(critChance > 50)
        {
            critChance = 50;
        }

    }



    //*------- Gun Upgrades --------*//

    //Projectile speed upgrade
    public void UpgradeProjectileSpeed(float amount)
    {
        ProSpeedUpgraded++;
        projectileSpeed += amount;
    }
    public void RemoveUpgradeProjectileSpeed(float amount)
    {
        ProSpeedUpgraded--;
        projectileSpeed -= amount;
    }

    //Projectile Damage upgrade
    public void UpgradeProjectileDamage(float amount)
    {
        ProDamageUpgraded++;
        projectileDamage += amount;
        BaseDamage += amount;
    }
    public void RemoveUpgradeProjectileDamage(float amount)
    {
        ProDamageUpgraded--;
        projectileDamage -= amount;
        BaseDamage -= amount;
    }
    
    //Fire Rate upgrades
    public void UpgradeFireRate(float amount)
    {
        FireRateUpgraded++;
        _fireRate -= amount;
    }
    public void RemoveUpgradeFireRate(float amount)
    {
        FireRateUpgraded--;
        _fireRate += amount;
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
        ProjectileSize += new Vector3(amount,amount,amount);
    }
    public void RemoveProjectileSize(float amount)
    {
        projectileSizeUpgraded--;
        ProjectileSize -= new Vector3(amount,amount,amount);
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
        CritChanceUpgraded++;
        critChance += amount;
    }
    public void RemoveCritChance(float amount)
    {
        CritChanceUpgraded--;
        critChance -= amount;
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
    public void UpgradeImpactExpolosion(float amount)
    {
        ExplosionUpgraded++;
        ExplosionArea += amount;
        explosiveCountUpgraded++;
    }
    public void RemoveImpactExplosion(float amount)
    {
        ExplosionUpgraded--;
        ExplosionArea -= amount;
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
        playerSpeed += amount;
    }

    //money Gain
    public void UpgradeMoney(float amount)
    {
        moneyManager.IncreaseMoney(amount);
    }

    //Give Random Item
    public void RandomItem()
    {
        Item newItem = GameManager.instance.WaveitemList[Random.Range(0, GameManager.instance.WaveitemList.Count)];

        Inventory.instance.AddItem(Instantiate(newItem));
    }

    //Dash Cooldown
    public void DashCooldown(float amount)
    {
        _dashCooldownTime -= amount;
    }

    //*------- Player upgrades --------*//


}
