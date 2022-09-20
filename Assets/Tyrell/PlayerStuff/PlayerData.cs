using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    #region singleton
    public static PlayerData instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    //Scripts
    public LevelSystem _levelSystem;
    public Upgradeables _upgradeables;

    //Saved variables
    //levels
    public int _Level;
    int DefaultLevel = 1;
    public float _currentXP;
    float DefaultCurrentXp = 0;
    public int _nextLevelXp;
    int DefaultNextLevelXp = 0;
    public int _xpPoints;
    int DefaultXpPoints = 0;

    //upgrades
    int DefaultUpgradeLevel = 0;

    public Item explosion;
    public int _explosionLevel;
    

    public Item Damage;
    public int _damageLevel;

    public Item fireRate;
    public int _fireRateLevel;





    public static int TutorialComplete = 0;
    int tutorialDefault = 0;

    public void Start()
    {
        LoadData(); 
       

        _levelSystem.level = _Level;
        _levelSystem.currentXp = _currentXP;
        _levelSystem.nextLevelXp = _nextLevelXp;
        _levelSystem.EXPpoints = _xpPoints;

        //Upgrades
        explosion.level = _explosionLevel;
        explosion.UpgradeAmount = 0;
        explosion.baselevel = 0;
        explosion.UpdateUpgrade();

        Damage.level = _damageLevel;
        Damage.UpgradeAmount = 0;
        Damage.baselevel = 0;
        Damage.UpdateUpgrade();

        fireRate.level = _fireRateLevel;
        fireRate.UpgradeAmount = 0;
        fireRate.baselevel = 0;
        fireRate.UpdateUpgrade();
    }

    private void Update()
    {
        _Level = _levelSystem.level;
        _currentXP = _levelSystem.currentXp;
        _nextLevelXp = _levelSystem.nextLevelXp;
        _xpPoints = _levelSystem.EXPpoints;
        _explosionLevel = explosion.level;
        _damageLevel = Damage.level;
        _fireRateLevel = fireRate.level;
    }
    public void LoadData()
    {
        TutorialComplete = ES3.Load("TutorialComplete", tutorialDefault);
        _Level = ES3.Load("SavedLevel", DefaultLevel);
        _currentXP = ES3.Load("SavedXp", DefaultCurrentXp);
        _nextLevelXp = ES3.Load("NextLevelXp", DefaultNextLevelXp);
        _xpPoints = ES3.Load("XPPoints", DefaultXpPoints);
        _explosionLevel = ES3.Load("ExplosionUpgradeLevel", DefaultUpgradeLevel);
        _damageLevel = ES3.Load("DamageUpgradeLevel", DefaultUpgradeLevel);
        _fireRateLevel = ES3.Load("FireRateUpgradeLevel", DefaultUpgradeLevel);
    }

    public void SaveData()
    {
        ES3.Save("SavedLevel", _Level);
        ES3.Save("SavedXp", _currentXP);
        ES3.Save("NextLevelXp", _nextLevelXp);
        ES3.Save("XPPoints", _xpPoints);
        ES3.Save("ExplosionUpgradeLevel", _explosionLevel);
        ES3.Save("DamageUpgradeLevel", _damageLevel);
        ES3.Save("FireRateUpgradeLevel", _fireRateLevel);
    }


}
