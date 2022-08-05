using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public WardenBossManager healthManager;

    public void EnemyTakeDamage(float amount)
    {
        healthManager.GetComponent<WardenBossManager>().Health -= amount;

    }
}
