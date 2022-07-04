using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    //Scripts
    public Upgradeables stats;
    public EnemySpawnSystem EnemySpawn;
    public movement playermovement;

    //UI Elements
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI NextWaveText;
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI ProSpeedText;
    public TextMeshProUGUI FireRateText;
    public TextMeshProUGUI NumOfProjectiles;

    public Slider dashCoolDown;
    

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
        EnemySpawn = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawnSystem>();
        playermovement = GameObject.FindWithTag("Player").GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Stats Text
        HealthText.text = "Health " + stats.Health;

        //Gun stats texts
        DamageText.text = "Damage: " + stats.projectileDamage;
        ProSpeedText.text = "Projectile Speed: " + stats.projectileSpeed;
        FireRateText.text = "Fire Rate: " + stats._fireRate;
        NumOfProjectiles.text = "Projectiles: " + stats.NumberOfProjectile;

        //Dashing Text
        dashCoolDown.value = playermovement._dashCooldown;
        if (playermovement._isDashing)
        {
            
            
        }
        else
        {
            
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
