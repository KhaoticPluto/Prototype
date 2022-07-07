using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeEnemy : EnemyAiController
{
    public GameObject projectile;
    public Animator animator;

    public override void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            animator.SetTrigger("isAttacking");
            
            ///Attack code here
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code
            
             alreadyAttacked = true;
             Invoke(nameof(ResetAttack), timeBetweenAttacks);

            
            

        }
    }

}
