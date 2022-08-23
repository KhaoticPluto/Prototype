using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HudVariant : MonoBehaviour
{


    //Scripts
    public Upgradeables stats;

    public movement playermovement;

    public EnemySpawnSystem EnemySpawn;


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

    public GameObject PopUpBuyText;

    //different ui parents
    public GameObject HudParent;
    public GameObject SettingsParent;
    


    public TextMeshProUGUI NextWaveText;
    public TextMeshProUGUI WaveText;

    public void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();

        playermovement = GameObject.FindWithTag("Player").GetComponent<movement>();
        HudParent.SetActive(true);
        SettingsParent.SetActive(false);

        EnemySpawn = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawnSystem>();
    }


    public void Update()
    {
        //Player Stats Text
        HealthText.text = "Health " + stats.MaxHealth + " / " + stats.Health;
        MoneyText.text =  MoneyManager.Money;

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





        //Settings Stuff
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (HUDManager.isPaused)
            {
                //close inventory
                ResumeGame();

            }
            else
            {
                //openInventory
                PauseGame();
                InventoryUIHandler.instance.CloseInventory();
                WaveGameManager.instance.CloseShop();

            }
        }

        //Wave Text
        WaveText.text = "Wave : " + EnemySpawn.WaveNumber;
        if (EnemySpawn.nextWave)
        {

            EnemySpawn.NextWaveTimer -= Time.deltaTime;
            NextWaveText.gameObject.SetActive(true);
            DisplayTime(EnemySpawn.NextWaveTimer);
            if (EnemySpawn.showItems)
            {
                EnemySpawn.ShowItemChooser();
                EnemySpawn.showItems = false;
            }

        }
        else
        {
            NextWaveText.gameObject.SetActive(false);
            EnemySpawn.NextWaveTimer = EnemySpawn.resetTimer;
        }
    }


    public void ResumeGame()
    {
        HUDManager.isPaused = false;
        Time.timeScale = 1;
        SettingsParent.SetActive(false);
        HudParent.SetActive(true);
    }

    public void PauseGame()
    {
        HUDManager.isPaused = true;
        Time.timeScale = 0;

        SettingsParent?.SetActive(true);
        HudParent.SetActive(false);

    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        NextWaveText.text = "Next Wave " + string.Format("{1:00}", minutes, seconds);
    }
}
