using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float Damage;

    int pierceCount = 0;

    public bool isCritical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "WhatIsWall")
        {
            //Debug.Log("Hit Wall");
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            pierceCount++;
            collision.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
            Vector3 enemyPos = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y * 3, collision.gameObject.transform.position.z);

            //Transform parent = collision.gameObject.transform.GetChild(0);
            DamagePopUp.Create(enemyPos, Damage, isCritical);

            if(pierceCount > Upgradeables.instance.PierceCountUpgraded)
            {
                Destroy(gameObject);
                pierceCount = 0;
            
            }



        }
    }

}
