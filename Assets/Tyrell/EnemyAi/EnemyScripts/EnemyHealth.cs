using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public float Health = 35;
    public float MaxHealth = 35;
    public float XpGiven = 10;

    public EnemyAiController AiController;

    public Slider HealthSlider;

    private void Update()
    {
        HealthSlider.value = CalculateHealth();

        if (Health <= 0)
        {


            LevelSystem.instance.GainExperienceFlatRate(XpGiven);
            MoneyManager.instance.DropMoney();
            AiController.DestroyEnemy();
        }

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void EnemyTakeDamage(float amount, bool isCrit)
    {
        Health -= amount;
        float damageSpawn = Random.Range(0, 4);
        Vector3 enemyPos = new Vector3(transform.position.x + damageSpawn, transform.position.y + 5, transform.position.z);

        DamagePopUp.Create(enemyPos, amount, isCrit);

        AiController.IncreaseSightRange();
    }

    public void EnemyGainHealth(float amount)
    {
        Health += amount;
    }


    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

    

}
