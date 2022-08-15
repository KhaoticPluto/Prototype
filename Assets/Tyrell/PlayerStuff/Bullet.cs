using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;

    public float explosiveArea = 0;
    public float freezeTime = 0;


    int pierceCount = 0;
    int ricochetCount = 0;
    

    //these set the bool for the upgrades, if the upgrades are equipped they should be true, otherwise stay false
    public bool isCritical;
    public bool isRicochet;
    public bool isPierce;
    public bool isArmorPiercer;

    public Collider ricochet;
    public Collider Pierce;

    [SerializeField] private LayerMask WhatIsEnemy;
    public LayerMask WhatisWall;


    public GameObject Explosion;
    //damage spawn is the where the damage popup will spawn
    float damageSpawn;

    public Upgradeables _upgrades;

    void Start()
    {
        ricochet.enabled = isRicochet;
        Pierce.enabled = !isRicochet;
        _upgrades.GetComponent<Upgradeables>();
    }


     void Update()
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


    void OnTriggerEnter(Collider collision)
    {
        pierceCount++;


        if (collision.gameObject.tag == "Boss")
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



        if (collision.gameObject.tag == "Enemy")
        {
            damageSpawn = Random.Range(0, 3);
            
            collision.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage);
            Vector3 enemyPos = new Vector3(collision.gameObject.transform.position.x + damageSpawn, collision.gameObject.transform.position.y + 5, collision.gameObject.transform.position.z);

            DamagePopUp.Create(enemyPos, Damage, isCritical);
            if (_upgrades.explosiveCountUpgraded > 0)
            {
                Debug.Log("checkingEnemies");
                CheckForEnemies();
            }
            if (freezeTime > 0)
            {
                collision.gameObject.GetComponent<EnemyAiController>().StartFrozen(freezeTime);
            }
            
           

        }



        if ((WhatisWall.value & 1 << collision.gameObject.layer) != 0 && isArmorPiercer == false
            || collision.gameObject.tag == "Shield" && isArmorPiercer == false) //== 1<<collision.gameObject.layer)
        {
            
            Destroy(gameObject);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        ricochetCount++;
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
            if (freezeTime > 0)
            {
                collision.gameObject.GetComponent<EnemyAiController>().StartFrozen(freezeTime);
            }



        }

        if (collision.gameObject.tag == "Boss")
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

    /// <summary>
    /// for the explosion, will check for colliders in the physics overlapsphere
    /// will only check for layermask what is enemy
    /// </summary>
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




}
