using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;

    public float explosiveArea = 0;

    int pierceCount = 0;
    int ricochetCount = 0;

    public bool isCritical;
    public bool isRicochet;
    public bool isPierce;
    

    public Collider ricochet;
    public Collider Pierce;

    [SerializeField] private LayerMask WhatIsEnemy;

    public GameObject Explosion;
    float damageSpawn;

    public Upgradeables _upgrades;

    private void Start()
    {
        ricochet.enabled = isRicochet;
        Pierce.enabled = !isRicochet;
        _upgrades.GetComponent<Upgradeables>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            damageSpawn = Random.Range(0, 3);
            pierceCount++;
            collision.gameObject.GetComponent<BossHealth>().EnemyTakeDamage(Damage);
            Vector3 enemyPos = new Vector3(collision.gameObject.transform.position.x + damageSpawn, collision.gameObject.transform.position.y + 5, collision.gameObject.transform.position.z);

            DamagePopUp.Create(enemyPos, Damage, isCritical);
            if (_upgrades.explosiveCountUpgraded > 0)
            {
                
                CheckForEnemies();
            }

        }



        if (collision.gameObject.tag == "Enemy")
        {
            damageSpawn = Random.Range(0, 3);
            pierceCount++;
            collision.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
            Vector3 enemyPos = new Vector3(collision.gameObject.transform.position.x + damageSpawn, collision.gameObject.transform.position.y + 5, collision.gameObject.transform.position.z);

            DamagePopUp.Create(enemyPos, Damage, isCritical);
            if (_upgrades.explosiveCountUpgraded > 0)
            {
                Debug.Log("checkingEnemies");
                CheckForEnemies();
            }


            

        }

        if (collision.gameObject.tag == "Shield")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
            //Vector3 bulletBounce = new Vector3(0, collision.gameObject.transform.position.y + 5, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ricochetCount++;
        //Debug.Log(ricochetCount);
        if (collision.gameObject.tag == "Enemy")
        {
            damageSpawn = Random.Range(0, 3);
            collision.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
            Vector3 enemyPos = new Vector3(collision.gameObject.transform.position.x + damageSpawn, collision.gameObject.transform.position.y + 5, collision.gameObject.transform.position.z);

            DamagePopUp.Create(enemyPos, Damage, isCritical);

            if (_upgrades.explosiveCountUpgraded > 0)
            {
                CheckForEnemies();
            }
            


        }

        if(collision.gameObject.tag == "Boss")
        {
            damageSpawn = Random.Range(0, 3);
            collision.gameObject.GetComponent<BossHealth>().EnemyTakeDamage(Damage);
            Vector3 enemyPos = new Vector3(collision.gameObject.transform.position.x + damageSpawn, collision.gameObject.transform.position.y + 5, collision.gameObject.transform.position.z);

            DamagePopUp.Create(enemyPos, Damage, isCritical);

            if (_upgrades.explosiveCountUpgraded > 0)
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
            if(collider.gameObject.tag == "Enemy" )
            {
                damageSpawn = Random.Range(0, 4);
                GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
                explosion.transform.localScale = new Vector3(explosiveArea, explosiveArea, explosiveArea);
                collider.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
                Vector3 enemyPos = new Vector3(collider.gameObject.transform.position.x + damageSpawn, collider.gameObject.transform.position.y + 5, collider.gameObject.transform.position.z);

                
                DamagePopUp.Create(enemyPos, Damage / 2, isCritical);
                Destroy(explosion, 1.5f);
            }
            else if(collider.gameObject.tag == "Boss")
            {
                damageSpawn = Random.Range(0, 4);
                GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
                explosion.transform.localScale = new Vector3(explosiveArea, explosiveArea, explosiveArea);
                collider.gameObject.GetComponent<BossHealth>().EnemyTakeDamage(Damage);
                Vector3 enemyPos = new Vector3(collider.gameObject.transform.position.x + damageSpawn, collider.gameObject.transform.position.y + 5, collider.gameObject.transform.position.z);


                DamagePopUp.Create(enemyPos, Damage / 2, isCritical);
                Destroy(explosion, 1.5f);
            }

        }
    }

    private void Update()
    {
        if (ricochetCount > _upgrades.ricochetCountUpgraded + 1)
        {
            Destroy(gameObject);
            ricochetCount = 0;
        }
        if (pierceCount > _upgrades.PierceCountUpgraded)
        {
            Destroy(gameObject);
            pierceCount = 0;

        }
    }




}
