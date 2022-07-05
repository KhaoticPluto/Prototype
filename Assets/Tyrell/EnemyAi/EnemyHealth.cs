using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float Health;
    public float MaxHealth;

    public EnemyAiController AiController;
    public EnemyRandomsDropItem randItemDrop;
    public EnemyMoney eMoney;

    public Slider HealthSlider;

    private void Update()
    {
        HealthSlider.value = CalculateHealth();

        if (Health <= 0)
        {
            //Debug.Log("Enemy Died");
            AiController.DestroyEnemy();
            randItemDrop.RandomlyDropItem();
            eMoney.GetComponent<EnemyMoney>().DropMoney();
        }

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
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


    float CalculateHealth()
    {
        return Health / MaxHealth;
    }

}
