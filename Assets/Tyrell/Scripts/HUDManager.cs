using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    
    

    //Scripts
    public Upgradeables stats;
    
    public movement playermovement;
    

    //UI Elements
    public TextMeshProUGUI HealthText;  
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI ProSpeedText;
    public TextMeshProUGUI FireRateText;
    public TextMeshProUGUI NumOfProjectiles;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI PriceCountText;
    public TextMeshProUGUI RicochetCountText;
    public TextMeshProUGUI CritChance;


    public Slider dashCoolDown;


    //different ui parents
    public GameObject HudParent;
    public GameObject SettingsParent;
    public bool isPaused;

    // Start is called before the first frame update
    public void Start()
    {
        if(GameObject.FindWithTag("Player") != null)
        {
            stats = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
        }
       
        if(GameObject.FindWithTag("Player") != null)
        {
            playermovement = GameObject.FindWithTag("Player").GetComponent<movement>();
        }
        
        HudParent.SetActive(true);
        SettingsParent.SetActive(false);
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(stats != null && playermovement != null)
        {
            //Player Stats Text
            HealthText.text = "Health " + stats.MaxHealth + " / " + stats.Health;
            MoneyText.text = "Instant Noodles " + MoneyManager.Money;

            //Gun stats texts
            DamageText.text = "Damage: " + stats.projectileDamage;
            ProSpeedText.text = "Projectile Speed: " + stats.projectileSpeed;
            FireRateText.text = "Fire Rate: " + stats._fireRate;
            NumOfProjectiles.text = "Projectiles: " + stats.NumberOfProjectile;
            CritChance.text = "Crit Chance: " + stats.critChance + "%";
            PriceCountText.text = "Pierce Count: " + stats.PierceCountUpgraded;
            RicochetCountText.text = "Ricochet Count: " + stats.ricochetCountUpgraded;

            //Dashing Text
            dashCoolDown.value = playermovement._dashCooldown;
        }
        
        

        


        //Settings Stuff
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //close inventory
                ResumeGame();

            }
            else
            {
                //openInventory
                PauseGame();
                
            }
        }



    }


    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        SettingsParent.SetActive(false);
        HudParent.SetActive(true);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;

        SettingsParent?.SetActive(true);
        HudParent.SetActive(false);

    }


}
