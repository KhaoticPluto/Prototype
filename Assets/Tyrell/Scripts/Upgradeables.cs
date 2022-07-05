using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeables : MonoBehaviour
{


    //upgrade values
    public float projectileSpeed = 700;

    public float projectileDamage = 1;

    public float _fireRate = 1;

    public float _nextFire;

    public int NumberOfProjectile = 1;

    public float SpreadFactor = 0.2f;

    public Vector3 ProjectileSize = new Vector3(0.5f,0.5f,0.5f);

    //other values
    public float ProjectileLifeTime = 1;

    public float Health = 100;

    public float playerSpeed = 15;

    public float _dashSpeed = 40f;
    public float _dashTime = 0.25f;
    public float _dashCooldownTime = 3;

    public static float ItemDropChance = 20;

    private void Start()
    {
        //projectileDamage = 1;
        //projectileSpeed = 100;
        //_fireRate = 1;
        //NumberOfProjectile = 1;
        //SpreadFactor = 0.5f;
        //ProjectileLifeTime = 1;
    }

    //Projectile speed upgrade
    public void UpgradeProjectileSpeed(float amount)
    {
        projectileSpeed += amount;
    }
    public void RemoveUpgradeProjectileSpeed(float amount)
    {
        projectileSpeed -= amount;
    }

    //Projectile Damage upgrade
    public void UpgradeProjectileDamage(float amount)
    {
        projectileDamage += amount;
    }
    public void RemoveUpgradeProjectileDamage(float amount)
    {
        projectileDamage -= amount;
    }
    
    //Fire Rate upgrades
    public void UpgradeFireRate(float amount)
    {
        _fireRate -= amount;
    }
    public void RemoveUpgradeFireRate(float amount)
    {
        _fireRate += amount;
    }

    //increase amount of Projectiles upgrade
    public void UpgradeNumOfProjectiles(float amount)
    {
        NumberOfProjectile += (int)amount;
    }
    public void RemoveUpgradeNumOfProjectiles(float amount)
    {
        NumberOfProjectile -= (int)amount;
    }

    //ProjectileSize upgrades
    public void UpgradeProjectileSize(float amount)
    {
        ProjectileSize += new Vector3(amount,amount,amount);
    }
    public void RemoveProjectileSize(float amount)
    {
        ProjectileSize -= new Vector3(amount,amount,amount);
    }


    //Reset upgrades if lowered past lowest amount
    private void Update()
    {
        if(_fireRate <= 0.01f)
        {
            _fireRate = 0.1f;
        }

        if(projectileSpeed >= 700)
        {
            projectileSpeed = 600;
        }

        

    }
}
