using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    //Scripts
    public Upgradeables stats;

    //UI Elements
    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI ProSpeedText;
    public TextMeshProUGUI FireRateText;
    public TextMeshProUGUI NumOfProjectiles;
    public TextMeshProUGUI PriceCountText;
    public TextMeshProUGUI RicochetCountText;
    public TextMeshProUGUI CritChance;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            stats = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stats != null)
        {

            //Gun stats texts
            DamageText.text = "Damage: " + stats.projectileDamage;
            ProSpeedText.text = "Projectile Speed: " + stats.projectileSpeed;
            FireRateText.text = "Fire Rate: " + stats._fireRate;
            NumOfProjectiles.text = "Projectiles: " + stats.NumberOfProjectile;
            CritChance.text = "Crit Chance: " + stats.critChance + "%";
            PriceCountText.text = "Pierce Count: " + stats.PierceCountUpgraded;
            RicochetCountText.text = "Ricochet Count: " + stats.ricochetCountUpgraded;
        }
    }
}
