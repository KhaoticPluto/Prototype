using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyGuardVar : EnemyAiController
{
    public Animator animator;

    public GameObject projectile;

    public float bulletVelocity = 0f;
    public override void AttackPlayer()
    {
        
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!alreadyAttacked)
        {
            ///Attack code here
            
            animator.SetTrigger("isAttacking");

            Rigidbody rb = Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity).GetComponent<Rigidbody>();
            rb.gameObject.transform.LookAt(player.transform);
            rb.velocity = transform.forward * bulletVelocity;
            rb.gameObject.transform.Rotate(0, -90, 0);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }
}
