using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    #region singleton
    public static StoreManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion



    private void Start()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 1;
            CloseShop();
        }
    }

    public void CloseShop()
    {
        this.gameObject.SetActive(false);
        GameManager.instance.DestroyItemInfo();
    }



}
