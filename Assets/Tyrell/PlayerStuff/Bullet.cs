using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;

    public float explosiveArea = 0;

    int pierceCount = 0;


    public bool isCritical;
    public bool isRicochet;
    

    public Collider ricochet;
    public Collider Pierce;

    [SerializeField] private LayerMask WhatIsEnemy;

    public GameObject Explosion;
    int damageSpawn;



    private void Start()
    {
        ricochet.enabled = isRicochet;
        Pierce.enabled = !isRicochet;
        damageSpawn = Random.Range(1, 2);
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
            Vector3 enemyPos = new Vector3(collision.gameObject.transform.position.x + damageSpawn, collision.gameObject.transform.position.y * 3, collision.gameObject.transform.position.z);

            //Transform parent = collision.gameObject.transform.GetChild(0);
            DamagePopUp.Create(enemyPos, Damage, isCritical);
            if (Upgradeables.instance.explosiveCountUpgraded > 0)
            {
                Debug.Log("checkingEnemies");
                CheckForEnemies();
            }
            if (pierceCount > Upgradeables.instance.PierceCountUpgraded)
            {
                Destroy(gameObject);
                pierceCount = 0;

            }
            


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Enemy")
        {
            
            pierceCount++;
            collision.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
            Vector3 enemyPos = new Vector3(collision.gameObject.transform.position.x + damageSpawn, collision.gameObject.transform.position.y * 3, collision.gameObject.transform.position.z);

            //Transform parent = collision.gameObject.transform.GetChild(0);
            DamagePopUp.Create(enemyPos, Damage, isCritical);

            if (Upgradeables.instance.explosiveCountUpgraded > 0)
            {
                CheckForEnemies();
            }



        }
    }

    void CheckForEnemies()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosiveArea, WhatIsEnemy);
        foreach (Collider collider in colliders)
        {
            if(collider.gameObject.tag == "Enemy")
            {
                damageSpawn = Random.Range(0, 4);
                GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
                explosion.transform.localScale = new Vector3(explosiveArea, explosiveArea, explosiveArea);
                collider.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
                Vector3 enemyPos = new Vector3(collider.gameObject.transform.position.x + damageSpawn, collider.gameObject.transform.position.y * 3, collider.gameObject.transform.position.z);

                
                DamagePopUp.Create(enemyPos, Damage / 2, isCritical);
                Destroy(explosion, 1.5f);
            }
        }
    }


    



}
