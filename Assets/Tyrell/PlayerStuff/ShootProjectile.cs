using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{

    public GameObject _pfBullet;
    public Upgradeables upgrades;

    public MousePosition mousepos;

    bool isCriticalHit;

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

            //changes value of the bullets before sending it
            bullet.GetComponent<Bullet>().Damage = CalculateDamage();
            bullet.GetComponent<Bullet>().isCritical = isCriticalHit;
            bullet.GetComponent<Bullet>().BulletSpeed = upgrades.projectileSpeed;
            bullet.transform.localScale = upgrades.ProjectileSize;

            //sends bullet in the direction the bullet is facing, bullet is facing towards cursor when fired
            bullet.transform.LookAt(mousepos.WorldPosition);
            Vector3 ShootDirection = bullet.transform.forward;
            ShootDirection.x += Random.Range(-upgrades.SpreadFactor, upgrades.SpreadFactor);
            ShootDirection.z += Random.Range(-upgrades.SpreadFactor, upgrades.SpreadFactor);
            bullet.GetComponent<Rigidbody>().velocity = ShootDirection * upgrades.projectileSpeed;

            //destorys bulet after its lifetime has passed
            Destroy(bullet, upgrades.ProjectileLifeTime);

        }
        
    }



    private float CalculateDamage()
    {
        float calCritChance = Random.Range(1, 100);
        if(upgrades.critChance >= calCritChance)
        {
            upgrades.projectileDamage = upgrades.projectileDamage * 2;
            isCriticalHit = true;
        }
        else
        {
            upgrades.projectileDamage = upgrades.BaseDamage;
            isCriticalHit = false;
        }
            

        return upgrades.projectileDamage;
    }
}
