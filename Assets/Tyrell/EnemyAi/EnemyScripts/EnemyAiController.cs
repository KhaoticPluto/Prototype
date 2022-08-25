using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiController : MonoBehaviour
{
    //nav mesh agent that should be on the enemy
    public NavMeshAgent agent;

    //players transform so enemy knows what to look for
    public Transform player;

    //layermask so the ai knows what is the ground and player
    public LayerMask whatIsGround, whatIsPlayer, whatIsntPlayer;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool isFrozen = false;
    public bool playerInSight = false;

    public GameObject Enemy;


    //Script for the roguelite mode enemy room spawn
    public EnemyRoomSpawn roomspawn;
    public bool IsRogueLite = false;

    void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        //this will find the player transform when the enemy is spawned ///very important
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        StartCoroutine(WaitBeforeAttack());
        
    }


    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (Physics.Linecast(transform.position, player.position, whatIsntPlayer))
        {
            playerInSight = false;
        }
        else
        {
            playerInSight = true;
        }

        //if any of theese are true it will set the enemies state
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange  && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && !isFrozen && playerInSight) AttackPlayer();
        
    }

    ///freeze
    public void StartFrozen(float freezeTime)
    {
        StartCoroutine(SetFrozen(freezeTime));
    }

    IEnumerator SetFrozen(float FreezeTime)
    {
        Color customColor = new Color(0, 0.9556165f, 1, 1);
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<Renderer>().material.SetColor("_BaseColor", customColor);
        GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", customColor);
        isFrozen = true;
        yield return new WaitForSeconds(FreezeTime);
        isFrozen = false;
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);
        GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", Color.white);
    }
    ///freeze

    public IEnumerator WaitBeforeAttack()
    {
        alreadyAttacked = true;
        yield return new WaitForSeconds(1.5f);
        alreadyAttacked = false;
    }

    //patrolling state where enemy can't see player they will walk in between two set walk points
    public virtual void Patroling()
    {
        //will search for a walk point in an area set in the inspectors walk point range
        if (!walkPointSet) SearchWalkPoint();

        //will set the destination that the enemy will go to
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }


    //will look for a walk point set in the inspector
    public virtual void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    //will chase the player if in sight range
    public virtual void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }


    //will attack the player if in attack range
    public virtual void AttackPlayer()
    {
        
    }


    //destorys enemy
    public void DestroyEnemy()
    {
        if (IsRogueLite == true )
        {
            roomspawn.RemoveEnemy(Enemy);
        }
        

        Destroy(Enemy);
        Debug.Log(Enemy + "enemy Destroyed");
        //only for the roguelite mode to check if it is the roguelite mode and remove from the room list
        

    }

    //resets the attack when called
    public virtual void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public IEnumerator BeingPulled()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Being Pulled");

    }


    //draws gizmos that you can see in the scene view when selecting the enemy
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
