using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    

    public List<Item> itemList = new List<Item>();

    
    public GameObject itemInfoPrefab;
    private GameObject currentItemInfo = null;

    public Transform mainCanvas;
    public Transform GunInventoryTransform;
    public Transform inventoryTransform;

    public float moveX;
    public float moveY;

    public GameObject ItemChoice;

    public GameObject Shop;
    public bool ShopOpen;

    public int WavesCompleted;

    private void Start()
    {
        Time.timeScale = 1;

        



        //find objects if not in slot
        ItemChoice = GameObject.FindWithTag("ItemChoice");
        Debug.Log("GameManager found " + ItemChoice);
        ItemChoice.SetActive(true);
        ItemChoice.GetComponent<ItemChoice>().EndOfWave();

        Shop = GameObject.FindWithTag("ShopManager");
        Debug.Log("GameManager found " + Shop);
        Shop.SetActive(false);

        //inventoryTransform = GameObject.FindWithTag("InventoryParent").transform;

        //mainCanvas = GameObject.FindWithTag("InventoryCanvas").transform;

        //GunInventoryTransform = GameObject.FindWithTag("GunInventory").transform;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Item newItem = itemList[Random.Range(0, itemList.Count)];

            Inventory.instance.AddItem(Instantiate(newItem));
        }

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
    }

    public void DestroyItemChoice()
    {
        ItemChoice.GetComponent<ItemChoice>().DestoryItems();
        ItemChoice.SetActive(false);
        
    }

    public void DisplayItemInfo(string itemName, string itemDescription, Vector2 buttonPos)
    {
        if (currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }

        buttonPos.x -= moveX;
        buttonPos.y += moveY;

        currentItemInfo = Instantiate(itemInfoPrefab, buttonPos, Quaternion.identity, mainCanvas);
        currentItemInfo.GetComponent<ItemInfo>().SetUp(itemName, itemDescription);
    }

    public void DestroyItemInfo()
    {
        if (currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }
    }

    void OpenShop()
    {
        ShopOpen = true;
        Shop.SetActive(true);
        Time.timeScale = 0.7f;
    }
    
    void CloseShop()
    {
        ShopOpen = false;
        Shop.SetActive(false);
        Time.timeScale = 1;
        DestroyItemInfo();
    }
}
