using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    #region singleton
    public static TutorialManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public void TutorialComplete()
    {
        ES3.Save("TutorialComplete", 1);
        PlayerData.TutorialComplete = 1;
        LoadSceneManager.instance.LoadStartingArea();

    }




}
