using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health;

    public EnemyAiController AiController;

    private void Update()
    {
        if (Health <= 0)
        {
            //Debug.Log("Enemy Died");
            AiController.DestroyEnemy();
        }


    }

    public void EnemyTakeDamage(float amount)
    {
        Health -= amount;
        //Debug.Log("Enemy took damage " + amount);
    }

    public void EnemyGainHealth(float amount)
    {
        Health += amount;
    }

}
