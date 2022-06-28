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
            Shoot();
        }
        else{
            if (Time.time > upgrades._nextFire && upgrades._fireRate > 0)
            {
                upgrades._nextFire = Time.time + upgrades._fireRate;
                Shoot();
            }
 
        }
            
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(_pfBullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>();
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * upgrades.projectileSpeed);
        Destroy(bullet, 5);
    }
}
