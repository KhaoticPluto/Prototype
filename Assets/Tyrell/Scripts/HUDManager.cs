using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{

    //Player Upgrade
    public TextMeshProUGUI moneyCounter;
    public TextMeshProUGUI healthCounter;
    
    public TextMeshProUGUI speedCounter;
    //public TextMeshProUGUI inventoryCounter;

    //Scripts
    public Upgradeables stats;
    
    public movement playermovement;
    

    //UI Elements
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI PriceCountText;
    public TextMeshProUGUI healthText;

    public Slider dashCoolDown;
    public Slider healthBar;


    //different ui parents
    public GameObject HudParent;
    public GameObject SettingsParent;
    public static bool isPaused = false;

    // Start is called before the first frame update
    public void Start()
    {

            stats = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
            playermovement = GameObject.FindWithTag("Player").GetComponent<movement>();
        
        HudParent.SetActive(true);
        SettingsParent.SetActive(false);

        isPaused = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if(stats != null && playermovement != null)
        {
            //Player Stats Text
            //HealthText.text = "Health " + stats.MaxHealth + " / " + stats.Health;
            healthBar.value = stats.Health;
            healthText.text = stats.Health + " / " + stats.MaxHealth;
            MoneyText.text = " " + MoneyManager.Money;

            healthCounter.text = " " + PlayerItemUpgradeRemove.instance.MaxHealthItem;
            moneyCounter.text = " " + PlayerItemUpgradeRemove.instance.IncreaseMoneyItem;
            speedCounter.text = " " + PlayerItemUpgradeRemove.instance.SpeedItem;
            //inventoryCounter.text = " " + PlayerItemUpgradeRemove.instance.InventoryItem;

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
                ///closes inventory if player presses pause while inventory open
                InventoryUIHandler.instance.CloseInventory();
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
        ES3AutoSaveMgr.Current.Save();
        SettingsParent?.SetActive(true);
        HudParent.SetActive(false);

    }


}
