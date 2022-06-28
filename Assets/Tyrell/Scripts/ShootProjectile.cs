using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{

    public GameObject _pfBullet;
    public Upgradeables upgrades;


    

    private void Start()
    {
        upgrades.GetComponent<Upgradeables>();
    }

    public void ComponentShoot()
    {
        if (upgrades._fireRate == 0)
        {
            Shoot(upgrades.NumberOfProjectile);
        }
        else{
            if (Time.time > upgrades._nextFire && upgrades._fireRate > 0)
            {
                upgrades._nextFire = Time.time + upgrades._fireRate;
                Shoot(upgrades.NumberOfProjectile);
            }
 
        }
            
    }

    void Shoot(int NumberOfProjectiles)
    {
        
        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            Vector3 ShootDirection = transform.forward;
            ShootDirection.x += Random.Range(-upgrades.SpreadFactor, upgrades.SpreadFactor);
            ShootDirection.z += Random.Range(-upgrades.SpreadFactor, upgrades.SpreadFactor);
            GameObject bullet = Instantiate(_pfBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>();
            bullet.GetComponent<Rigidbody>().AddForce(ShootDirection * upgrades.projectileSpeed);
            Destroy(bullet, 5);
            
        }
        
    }
}
