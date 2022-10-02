using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGameManager : MonoBehaviour
{
    #region singleton
    public static WaveGameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public GameObject ItemChoice;

    public GameObject shop;
    public GameObject shopOpenText;
    public bool ShopOpen;

    public int WavesCompleted;

    public EnemySpawnSystem spawnSystem;

    private void Start()
    {
        //find objects if not in slot
        
        ItemChoice.SetActive(true);
        ItemChoice.GetComponent<ItemChoice>().EndOfWave();

        //shop
        
        shop.SetActive(false);
        ShopOpen = false;
    }

    private void Update()
    {
        if (spawnSystem.nextWave)
        {
            shopOpenText.SetActive(true);
        }
        else
        {
            shopOpenText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.T) )
        {
            if (ShopOpen)
            {
                CloseShop();
            }
            else
            {
                if(InventoryUIHandler.instance.inventoryOpen == false & HUDManager.isPaused == false & spawnSystem.nextWave == true)
                OpenShop();
            }
        }
    }


    public void ShowItemChoice()
    {
        ItemChoice.SetActive(true);
        ItemChoice.GetComponent<ItemChoice>().EndOfWave();
        if (ShopOpen)
        {
            CloseShop();
        }
    }

    public void DestroyItemChoice()
    {
        ItemChoice.GetComponent<ItemChoice>().DestoryItems();
        ItemChoice.SetActive(false);

    }

    void OpenShop()
    {
        ShopOpen = true;
        shop.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        ShopOpen = false;
        shop.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.DestroyItemInfo();
    }

}
