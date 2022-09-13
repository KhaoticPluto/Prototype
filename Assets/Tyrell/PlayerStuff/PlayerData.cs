using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //Scripts
    public LevelSystem _levelSystem;
    public Upgradeables _upgradeables;

    //Saved variables


    public static int TutorialComplete = 0;
    int tutorialDefault = 0;

    public void Start()
    {
       TutorialComplete = ES3.Load("TutorialComplete", tutorialDefault);




    }


}
