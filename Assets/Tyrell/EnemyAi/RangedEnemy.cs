using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyAiController
{
    public GameObject projectile;

    public override void AttackPlayer()
    {
        

        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity).GetComponent<Rigidbody>();
            rb.transform.LookAt(player.transform);
            rb.velocity = transform.forward * 30f;
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        
    }

}
