using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAoeRange : EnemyAiController
{
    public GameObject projectile;
    int ProjectilesFired = 10;

    Vector3 position = new Vector3();
    float t = 0f;

    public override void AttackPlayer()
    {
        Vector3 offsetPlayer = player.transform.position - transform.position;
        Vector3 dir = Vector3.Cross(offsetPlayer, Vector3.up);
        agent.SetDestination(transform.position + dir);

        //Make sure enemy doesn't move
        //agent.SetDestination(transform.position);

        transform.LookAt(player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!alreadyAttacked)
        {
            ///Attack code here
            for (int i = 0; i < ProjectilesFired; i++)
            {
                Rigidbody rb = Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity).GetComponent<Rigidbody>();

                Vector3 ShootDirection = transform.forward;
                ShootDirection.x += Random.Range(-0.5f, 0.5f);
                ShootDirection.z += Random.Range(-0.5f, 0.5f);
                
                rb.transform.LookAt(player.transform);
                rb.velocity = ShootDirection * 30f ;
                //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            }

            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    

    public override void ChasePlayer()
    {
        agent.SetDestination(player.position);
        
        
    }


}
