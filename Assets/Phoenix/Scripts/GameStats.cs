using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStats : MonoBehaviour
{

    #region singleton
    public static GameStats instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    #region Variables
    //script ref
    public EnemyHealth enemy;
    public Upgradeables upgrades;

    //Stat Trackers
    public TextMeshProUGUI killStats;
    public TextMeshProUGUI longestRunStats;
    public TextMeshProUGUI LifeStats;
    public TextMeshProUGUI DeathStats;
    public TextMeshProUGUI upgradesCollected;
    public TextMeshProUGUI moneyCollected;
    public TextMeshProUGUI damageDealtStats;
    public TextMeshProUGUI damageTakenStats;
    //UI Parents
    public GameObject textparents;
    public GameObject BG;
    public GameObject Title;
    //Adds points
    public static float score;
    public static float time;
    public static float life;
    public static float money;

    public static bool isPaused = false;
    #endregion

    private void Start()
    {
        textparents.SetActive(true);
        BG.SetActive(true);
        Title.SetActive(true);
        isPaused = false;
        score = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        //press button/key opens game stats overall
        if (Input.GetKeyDown(KeyCode.U))
        {
            //close Stats
            OpenStats();
        }
        else
        {
            CloseStats();
        }

        
    }

    //Open Stats for the Player
    public void OpenStats()
    {
        isPaused = false;
        Time.timeScale = 1;
        textparents.SetActive(true);
        BG.SetActive(true);
        Title.SetActive(true);
    }

    //Closes the stat windows
    public void CloseStats()
    {
        isPaused = false;
        Time.timeScale = 0;
        textparents.SetActive(false);
        BG.SetActive(false);
        Title.SetActive(false);
    }
}
