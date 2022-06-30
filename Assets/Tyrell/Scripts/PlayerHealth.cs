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
        }

        
    }

    public void TakeDamage(float amount)
    {
        upgrade.Health -= amount;
        Debug.Log("Player took damage " + amount);
    }

    public void GainHealth(float amount)
    {
        upgrade.Health += amount;
    }

}