using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float Speed;

    public float explosiveArea = 0;
    public GameObject explosiveRemnants;
    public float freezeTime = 0;


    int pierceCount = 0;
    int ricochetCount = 0;
    

    //these set the bool for the upgrades, if the upgrades are equipped they should be true, otherwise stay false
    public bool isCritical;
    public bool isRicochet;
    public bool isPierce;

    //set bonuses
    public bool isArmorPiercer;
    public bool isMegaRicochet;
    public bool isExplosionMagnet;
    public bool isSeeking;


    public Collider ricochet;
    public Collider Pierce;

    public LayerMask WhatIsEnemy;
    public LayerMask WhatisWall;


    public GameObject Explosion;
    //damage spawn is the where the damage popup will spawn
    float damageSpawn;

    public Upgradeables _upgrades;

    public Rigidbody rb;

    void Start()
    {
        ricochet.enabled = isRicochet;
        Pierce.enabled = !isRicochet;
        _upgrades.GetComponent<Upgradeables>();
    }


     void Update()
    {
        if (ricochetCount > _upgrades.ricochetCountUpgraded)
        {
            Destroy(gameObject);
            ricochetCount = 0;
        }
        if (pierceCount > _upgrades.PierceCountUpgraded)
        {
            Destroy(gameObject);
            pierceCount = 0;

        }

        if (isSeeking)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, explosiveArea * 10, WhatIsEnemy);
                Collider bestTarget = null;
                float closestDistanceSqr = Mathf.Infinity;
                Vector3 currentPosition = transform.position;
                foreach (Collider potentialTarget in enemies)
                {
                    Vector3 directionToTargets = potentialTarget.gameObject.transform.position - currentPosition;
                    float dSqrToTarget = directionToTargets.sqrMagnitude;
                    if (dSqrToTarget < closestDistanceSqr)
                    {
                        closestDistanceSqr = dSqrToTarget;
                        bestTarget = potentialTarget;
                    }


                }

            if(bestTarget != null)
            {
                SeekToTarget(bestTarget);
            }
            
        }
       

    }

    void SeekToTarget(Collider Target)
    {
        Vector3 directionToTarget = Target.transform.position - transform.position;
        Vector3 currentDirection = transform.forward;
        float maxTurnSpeed = 360f; // degrees per second
        Vector3 resultingDirection = Vector3.RotateTowards(currentDirection, directionToTarget, maxTurnSpeed * Mathf.Deg2Rad * Time.deltaTime, 1f);
        transform.rotation = Quaternion.LookRotation(resultingDirection);
        rb.velocity = resultingDirection * Speed;
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
        transform.forward = rb.velocity;

        ///Mega Ricochet set bonus
        if (isMegaRicochet)
        {
            Damage += 1;
            rb.AddForce(rb.velocity / 5 , ForceMode.VelocityChange);
        }
        ///

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

            Destroy(this.gameObject);

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
            Destroy(this.gameObject);
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

                ///Explosion Magnet set bonus
                if (isExplosionMagnet)
                {
                    GameObject remnants = Instantiate(explosiveRemnants, transform.position, Quaternion.Euler(-90, 0,0));
                    ParticleSystem ps = remnants.GetComponent<ParticleSystem>();
                    var sh = ps.shape;
                    sh.radius = explosiveArea / 2;
                    SphereCollider sphere = remnants.GetComponent<SphereCollider>();
                    sphere.radius = explosiveArea / 2;
                    remnants.GetComponent<EnvironmentalDangers>().radius = explosiveArea / 2;
                    Destroy(remnants, 5);

                }
                //
                collider.gameObject.GetComponent<EnemyHealth>().EnemyTakeDamage(Damage / 2);
                Vector3 enemyPos = new Vector3(collider.gameObject.transform.position.x + damageSpawn, collider.gameObject.transform.position.y + 5, collider.gameObject.transform.position.z);

                
                DamagePopUp.Create(enemyPos, Damage / 2, isCritical);
                Destroy(explosion, 1.5f);
            }
            else if(collider.gameObject.tag == "Boss")
            {
                damageSpawn = Random.Range(0, 4);
                GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
                explosion.transform.localScale = new Vector3(explosiveArea, explosiveArea, explosiveArea);
                collider.gameObject.GetComponent<BossHealth>().EnemyTakeDamage(Damage / 2);
                Vector3 enemyPos = new Vector3(collider.gameObject.transform.position.x + damageSpawn, collider.gameObject.transform.position.y + 5, collider.gameObject.transform.position.z);


                DamagePopUp.Create(enemyPos, Damage / 2, isCritical);
                Destroy(explosion, 1.5f);
            }

        }
    }

    


}
