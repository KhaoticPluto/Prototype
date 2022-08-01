using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudVariant : HUDManager
{
    public EnemySpawnSystem EnemySpawn;

    public TextMeshProUGUI NextWaveText;
    public TextMeshProUGUI WaveText;

    private void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();

        playermovement = GameObject.FindWithTag("Player").GetComponent<movement>();
        HudParent.SetActive(true);
        SettingsParent.SetActive(false);

        EnemySpawn = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawnSystem>();
    }


    private void Update()
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

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        NextWaveText.text = "Next Wave " + string.Format("{1:00}", minutes, seconds);
    }
}
