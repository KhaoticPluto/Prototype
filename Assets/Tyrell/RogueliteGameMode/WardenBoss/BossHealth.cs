using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour
{

    public float Health = 100;
    public float MaxHealth = 100;

    public TextMeshProUGUI WardenName;
    public Slider WardenHealthBar;

    private void Update()
    {
        WardenHealthBar.value = CalculateHealth();

        if (Health <= 0)
        {
            DestroyWardenBoss();
            
        }
    }

    public void EnemyTakeDamage(float amount, bool isCrit)
    {
        Health -= amount;
        float damageSpawn = Random.Range(0, 4);
        Vector3 enemyPos = new Vector3(transform.position.x + damageSpawn, transform.position.y + 15, transform.position.z);
        DamagePopUp.Create(enemyPos, amount, isCrit);
    }

    public void DestroyWardenBoss()
    {
        Destroy(gameObject);
    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

}
