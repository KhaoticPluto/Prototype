using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Upgradeables upgrade;

    bool Invincibility;

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
            LoadSceneManager.instance.LoadStartingArea();
            
        }

        if (upgrade.Health > upgrade.MaxHealth)
        {
            upgrade.Health = upgrade.MaxHealth;
        }
        
    }

    public void TakeDamage(float amount)
    {
        if (!Invincibility)
        {
            upgrade.Health -= amount;
            Debug.Log("Player took damage " + amount);
            DamagePopUp.Create(transform.position + Vector3.up, amount, false);
        }
        
        StartCoroutine(Invincible(0.5f));
    }

    public void GainHealth(float amount)
    {
        upgrade.Health += amount;
    }

    IEnumerator Invincible(float length)
    {
        Invincibility = true;
        yield return new WaitForSeconds(length);
        Invincibility = false;
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
    }

}
