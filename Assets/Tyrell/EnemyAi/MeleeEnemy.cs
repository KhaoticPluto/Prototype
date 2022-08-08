using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeEnemy : EnemyAiController
{
    
    public Animator animator;
    

    

    public override void AttackPlayer()
    {
        //MeleeWeaponCollider.enabled = true;
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!alreadyAttacked)
        {
            ///Attack code here
            animator.SetTrigger("isAttacking");
            
            
            ///End of attack code
            
             alreadyAttacked = true;
             Invoke(nameof(ResetAttack), timeBetweenAttacks);

            
            

        }
    }

    [SerializeField]
    private Transform agentTransform;

    private float zigZagDelta = 2;

    private float zigZagDistance = 30;

    Vector3 ZigZagStrafe()
    {
        // using sinus to generate zigzag between -1 and 1 , multiplying with some magnitude
        float t = Mathf.Sin(zigZagDelta) * zigZagDistance;
        // this is in local space
        Vector3 zigZagDisplacementLocal = Vector3.right * t;
        // this is now in world space
        Vector3 zigZagDisplacementWorld = agentTransform.TransformDirection(zigZagDisplacementLocal);

        return zigZagDisplacementWorld;
    }

    public override void ChasePlayer()
    {
        zigZagDelta += Time.deltaTime;

        Vector3 movementPos = player.position;
        movementPos += ZigZagStrafe(); // add the offset from the zigzag
        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        agent.SetDestination(movementPos);
    }


    public override void ResetAttack()
    {
        alreadyAttacked=false;
        //MeleeWeaponCollider.enabled = false;
    }


}
