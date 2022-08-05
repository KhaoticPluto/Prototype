using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WardenAiController : MonoBehaviour
{
    //nav mesh agent that should be on the enemy
    public NavMeshAgent agent;

    //players transform so enemy knows what to look for
    public Transform player;


    //layermask so the ai knows what is the ground and player
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    //States
    public float sightRange, attackRange, ChargeRange;
    public bool playerInSightRange, playerInAttackRange, playerInChargeRange;

    bool ChargeReady = false;
    public float TimeToCharge = 15;
    public float NextCharge;

    //AnimationPlayer
    public WardenBossAnimation _animator;

    //sets the animation states
    public bool AnimationStarted = false;
    public bool AnimationFinished = true;
    Vector3 Lastpos;


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
        _animator.GetComponent<WardenBossAnimation>();

    }


    private void Update()
    {

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInChargeRange = Physics.CheckSphere(transform.position, ChargeRange, whatIsPlayer);

        //if any of theese are true it will set the enemies state
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) WeaponSlam();

        if(ChargeReady == false)
        {
            if (Time.time > NextCharge && TimeToCharge > 0)
            {
                NextCharge = Time.time + TimeToCharge;
                ChargeReady = true;
            }
        }



        //if (playerInChargeRange && ChargeReady)
        //{
        //    ChargeAttack();
        //}

    }


    void Patroling()
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

    void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }


    //will chase the player if in sight range
    void ChasePlayer()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);

    }


    void ChargeAttack()
    {
        agent.SetDestination(transform.position);
        if (!alreadyAttacked)
        {
            transform.LookAt(player);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            
            

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        
        
    }

    void WeaponSlam()
    {
        agent.SetDestination(transform.position);
        if (!alreadyAttacked)
        {
            transform.LookAt(player);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    //resets the attack when called
    void ResetAttack()
    {
        alreadyAttacked = false;
        
    }

    public void animationFinished()
    {
        Lastpos = transform.position;
        AnimationFinished = true;
    }
     
 

    //draws gizmos that you can see in the scene view when selecting the enemy
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, ChargeRange);
    }

}