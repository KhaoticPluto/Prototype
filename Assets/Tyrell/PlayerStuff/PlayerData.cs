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
    public int _Level;
    int DefaultLevel = 1;
    public float _currentXP;
    float DefaultCurrentXp;
    public int _nextLevelXp;
    int DefaultNextLevelXp;

    public static int TutorialComplete = 0;
    int tutorialDefault = 0;

    public void Start()
    {
        LoadData(); 
       

        _levelSystem.level = _Level;
        _levelSystem.currentXp = _currentXP;
        _levelSystem.nextLevelXp = _nextLevelXp;

    }

    private void Update()
    {
        _Level = _levelSystem.level;
        _currentXP = _levelSystem.currentXp;
        _nextLevelXp = _levelSystem.nextLevelXp;

    }
    public void LoadData()
    {
        TutorialComplete = ES3.Load("TutorialComplete", tutorialDefault);
        _Level = ES3.Load("SavedLevel", DefaultLevel);
        _currentXP = ES3.Load("SavedXp", DefaultCurrentXp);
        _nextLevelXp = ES3.Load("NextLevelXp", DefaultNextLevelXp);
    }

    public void SaveData()
    {
        ES3.Save("SavedLevel", _Level);
        ES3.Save("SavedXp", _currentXP);
        ES3.Save("NextLevelXp", _nextLevelXp);
    }


}
