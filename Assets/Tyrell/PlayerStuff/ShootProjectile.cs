using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{

    public GameObject[] _pfBullet;
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
            ShootProjectiles(upgrades.NumberOfProjectile);
        }
        else{
            if (Time.time > upgrades._nextFire && upgrades._fireRate > 0)
            {
                upgrades._nextFire = Time.time + upgrades._fireRate;
                //Shoot(upgrades.NumberOfProjectile);
                StartCoroutine(ShootProjectiles(upgrades.NumberOfProjectile));
            }
 
        }
            
    }

    IEnumerator ShootProjectiles(int NumberOfProjectiles)
    {
        for (int i = 0; i < NumberOfProjectiles; i++)
        {

            GameObject bullet = Instantiate(_pfBullet[0], transform.position, Quaternion.identity);

            //changes value of the bullets before sending it
            bullet.GetComponent<Bullet>().Damage = CalculateDamage();
            bullet.GetComponent<Bullet>().isCritical = isCriticalHit;
            bullet.GetComponent<Bullet>().isRicochet = upgrades.Ricochet;
            bullet.GetComponent<Bullet>().explosiveArea = upgrades.ExplosionArea;
            

            bullet.transform.localScale = upgrades.ProjectileSize;

            //sends bullet in the direction the bullet is facing, bullet is facing towards cursor when fired
            
            bullet.transform.LookAt(mousepos.WorldPosition);
            
            Vector3 ShootDirection = bullet.transform.forward;
            ShootDirection.x += Random.Range(-upgrades.SpreadFactor, upgrades.SpreadFactor);
            ShootDirection.z += Random.Range(-upgrades.SpreadFactor, upgrades.SpreadFactor);
            bullet.GetComponent<Rigidbody>().velocity = ShootDirection * upgrades.projectileSpeed;


            //destorys bulet after its lifetime has passed
            Destroy(bullet, upgrades.ProjectileLifeTime);
            yield return new WaitForSeconds(.01f);
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
