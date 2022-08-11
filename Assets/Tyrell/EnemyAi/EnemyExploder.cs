using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExploder : EnemyAiController
{
    public GameObject Explosion;

    public float explosiveArea = 5;
    public float explosionDamage = 20;

    float flashinTimer;
    float nextFlash;

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //if any of theese are true it will set the enemies state
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && !isFrozen) AttackPlayer();

        //if (Time.time > nextFlash && flashinTimer > 0)
        //{
        //    upgrades._nextFire = Time.time + upgrades._fireRate;
        //}


    }

    public override void AttackPlayer()
    {
        agent.SetDestination(player.position);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!alreadyAttacked)
        {
            ///Attack code here
            
            GetComponent<NavMeshAgent>().speed = 30;
            GetComponent<NavMeshAgent>().acceleration = 20;
            StartCoroutine(ExplodeEnemy());
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);




        }
        
    }


    IEnumerator ExplodeEnemy()
    {

        //GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
        //GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", Color.red);
        //GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);
        //GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", Color.white);
        yield return new WaitForSeconds(5);
        CheckForPlayer();
        
        DestroyEnemy();
    }

    void CheckForPlayer()
    {

        GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(explosiveArea, explosiveArea, explosiveArea);
        Destroy(explosion, 1.5f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosiveArea, whatIsPlayer);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Player")
            {
                
                collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(explosionDamage);

                
            }
        }
    }
}
