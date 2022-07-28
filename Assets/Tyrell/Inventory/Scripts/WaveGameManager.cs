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
    public bool ShopOpen;

    public int WavesCompleted;

    private void Start()
    {
        //find objects if not in slot
        ItemChoice = GameObject.FindWithTag("ItemChoice");
        Debug.Log("GameManager found " + ItemChoice);
        ItemChoice.SetActive(true);
        ItemChoice.GetComponent<ItemChoice>().EndOfWave();

        //shop
        shop = GameObject.FindWithTag("shopmanager");
        Debug.Log("gamemanager found " + shop);
        shop.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (ShopOpen)
            {
                CloseShop();
            }
            else
            {

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
        Time.timeScale = 0.7f;
    }

    void CloseShop()
    {
        ShopOpen = false;
        shop.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.DestroyItemInfo();
    }

}
