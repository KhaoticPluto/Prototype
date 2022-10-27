using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public float Health = 35;
    public float MaxHealth = 35;
    public float XpGiven;
    float HitTime = 0.1f;

    public Vector3 pubDamageSpawn = Vector3.zero;

    public EnemyAiController AiController;

    public Slider HealthSlider;

    public GameObject EnemyDeathParticle;
    public GameObject EnemyHitParticle;
    public Color customColor;

    public Renderer[] RendMaterials;

    private void Update()
    {
        HealthSlider.value = CalculateHealth();

        if (Health <= 0)
        {
            EnemyKilled("EnemiesKilled");
        }

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }


    public virtual void EnemyKilled(string Name)
    {
        GameObject enemyDeathParticle = Instantiate(EnemyDeathParticle, transform.position + (Vector3.up * 2), Quaternion.identity);
        enemyDeathParticle.GetComponent<EnemyDeathParticle>().newColor = customColor;
        Destroy(enemyDeathParticle, 2);


        AchievementManager.instance.AddAchievementProgress(Name, 1);
        LevelSystem.instance.GainExperienceScalable(XpGiven, LevelSystem.instance.level);
        MoneyManager.instance.DropMoney();
        AiController.DestroyEnemy();
    }

    public void EnemyTakeDamage(float amount, bool isCrit)
    {
        StartCoroutine(SetHit());
        
        GameObject enemyHit = Instantiate(EnemyHitParticle, transform.position + (Vector3.up * 2), Quaternion.identity);
        enemyHit.GetComponent<EnemyDeathParticle>().newColor = customColor;
        Destroy(enemyHit, 2);
        Health -= amount;
        float damageSpawn = Random.Range(0, 4);
        Vector3 enemyPos = new Vector3(transform.position.x + damageSpawn, transform.position.y + 5, transform.position.z);

        DamagePopUp.Create(enemyPos + pubDamageSpawn, amount, isCrit);

        AiController.IncreaseSightRange();
    }

    IEnumerator SetHit()
    {
        Color customColor = new Color(0.9245283f, 0.3968494f, 0.3968494f, 1);
        if (!AiController.isFrozen)
        {
            foreach (Renderer mats in RendMaterials)
            {
                mats.GetComponent<Renderer>().material.SetColor("_BaseColor", customColor);
                mats.GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", customColor);
            }
        }
        

        
        yield return new WaitForSeconds(HitTime);

        if (!AiController.isFrozen)
        {
            foreach (Renderer mats in RendMaterials)
            {
                mats.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);
                mats.GetComponent<Renderer>().material.SetColor("_1st_ShadeColor", Color.white);
            }
        }
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
