using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health;

    private void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("Enemy Died");
            Destroy(gameObject);
        }


    }

    public void EnemyTakeDamage(float amount)
    {
        Health -= amount;
        Debug.Log("Player took damage " + amount);
    }

    public void EnemyGainHealth(float amount)
    {
        Health += amount;
    }

}
