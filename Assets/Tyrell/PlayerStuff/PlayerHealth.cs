using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Upgradeables upgrade;

    private void Start()
    {
        upgrade.GetComponent<Upgradeables>();
    }

    private void Update()
    {
        if (upgrade.Health <= 0)
        {
            Debug.Log("Player Died");
            //Analytics.instance.SendAnalytics();
            //Analytics.instance.GameCompletedAnalytics();
            LoadSceneManager.instance.LoadGameOver();
            
        }

        if (upgrade.Health > upgrade.MaxHealth)
        {
            upgrade.Health = upgrade.MaxHealth;
        }
        
    }

    public void TakeDamage(float amount)
    {
        upgrade.Health -= amount;
        Debug.Log("Player took damage " + amount);
        DamagePopUp.Create(transform.position + Vector3.up, amount, false);
    }

    public void GainHealth(float amount)
    {
        upgrade.Health += amount;
    }

}
