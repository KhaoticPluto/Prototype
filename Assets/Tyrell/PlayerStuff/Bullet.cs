using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;

    int pierceCount = 0;

    public bool isCritical;

    public LayerMask Ricochet;

    public float BulletSpeed;

    private void Start()
    {
        
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "WhatIsWall")
        {
            //Debug.Log("Hit Wall");
            
        }

        if (collision.gameObject.tag == "Enemy")
        {
            pierceCount++;
            collision.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
            Vector3 enemyPos = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y * 3, collision.gameObject.transform.position.z);

            //Transform parent = collision.gameObject.transform.GetChild(0);
            DamagePopUp.Create(enemyPos, Damage, isCritical);

            if (pierceCount > Upgradeables.instance.PierceCountUpgraded)
            {
                Destroy(gameObject);
                pierceCount = 0;

            }



        }
    }

    private void Update()
    {
        


        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Time.deltaTime * BulletSpeed + 1f, Ricochet))
        {
            Debug.Log("hit wall");
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(rot, 0, 0);
        }


    }

    

}
