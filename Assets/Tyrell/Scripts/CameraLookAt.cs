using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    #region singleton
    public static CameraLookAt instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public Transform Player;
    public Transform Boss;

    public void LookForBoss()
    {
        Boss = GameObject.FindWithTag("Boss").gameObject.transform;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Boss != null)
        {
            transform.position = Vector3.Lerp(Player.position, Boss.position, 0.5f);
        }
        else
        {
            transform.position = Player.position;
        }

    }
}
