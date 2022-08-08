using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardenBossHealth : MonoBehaviour
{
    public WardenBossManager healthManager;

    public void EnemyTakeDamage(float amount)
    {
        healthManager.GetComponent<WardenBossManager>().Health -= amount;

    }

    
}
