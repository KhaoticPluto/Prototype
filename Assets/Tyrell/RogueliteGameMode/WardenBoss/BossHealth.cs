using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public WardenBossManager healthManager;

    public void EnemyTakeDamage(float amount, bool isCrit)
    {
        healthManager.GetComponent<WardenBossManager>().Health -= amount;
        float damageSpawn = Random.Range(0, 4);
        Vector3 enemyPos = new Vector3(transform.position.x + damageSpawn, transform.position.y + 5, transform.position.z);
        DamagePopUp.Create(enemyPos, amount, isCrit);
    }
}
