using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{

    public GameObject _pfBullet;
    public Upgradeables upgrades;

    public MousePosition mousepos;



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
            
            GameObject bullet = Instantiate(_pfBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Damage = upgrades.projectileDamage;
            bullet.transform.LookAt(mousepos.WorldPosition);
            Vector3 ShootDirection = bullet.transform.forward;
            ShootDirection.x += Random.Range(-upgrades.SpreadFactor, upgrades.SpreadFactor);
            ShootDirection.z += Random.Range(-upgrades.SpreadFactor, upgrades.SpreadFactor);
            bullet.GetComponent<Rigidbody>().velocity = ShootDirection * upgrades.projectileSpeed;
            bullet.transform.localScale = upgrades.ProjectileSize;
            Destroy(bullet, upgrades.ProjectileLifeTime);

        }
        
    }
}
