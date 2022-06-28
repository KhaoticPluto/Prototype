using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeables : MonoBehaviour
{
    public float projectileSpeed = 700;
    public float projectileDamage = 1;

    public float _fireRate = 1;
    public float _nextFire;

    private void Start()
    {
        projectileDamage = 1;
        projectileSpeed = 700;
        _fireRate = 1;

    }

    public void UpgradeProjectileSpeed(float amount)
    {
        projectileSpeed += amount;
    }

    public void RemoveUpgradeProjectileSpeed(float amount)
    {
        projectileSpeed -= amount;
    }

    public void UpgradeProjectileDamage(float amount)
    {
        projectileDamage += amount;
    }
    public void RemoveUpgradeProjectileDamage(float amount)
    {
        projectileDamage -= amount;
    }

    public void UpgradeFireRate(float amount)
    {
        _fireRate -= amount;
    }
    public void RemoveUpgradeFireRate(float amount)
    {
        _fireRate += amount;
    }


    private void Update()
    {
        if(_fireRate <= 0.1f)
        {
            _fireRate = 0.15f;
        }

        if(projectileSpeed >= 1500)
        {
            projectileSpeed = 1400;
        }


    }
}
