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

    public Upgradeables upgrade;

    public List<Item> itemList = new List<Item>();

    public Transform canvas;
    public GameObject itemInfoPrefab;
    private GameObject currentItemInfo = null;

    public Transform mainCanvas;
    public Transform GunInventoryTransform;
    public Transform inventoryTransform;

    public float moveX;
    public float moveY;

    public GameObject ItemChoice;


    private void Start()
    {
        if(GameObject.FindWithTag("Player") != null)
        {
            upgrade = GameObject.FindWithTag("Player").GetComponent<Upgradeables>();
            Debug.Log("found " + upgrade);
        }
        ItemChoice = GameObject.FindWithTag("ItemChoice");
        ItemChoice.SetActive(false);
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Item newItem = itemList[Random.Range(0, itemList.Count)];

            Inventory.instance.AddItem(Instantiate(newItem));
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

        currentItemInfo = Instantiate(itemInfoPrefab, buttonPos, Quaternion.identity, canvas);
        currentItemInfo.GetComponent<ItemInfo>().SetUp(itemName, itemDescription);
    }

    public void DestroyItemInfo()
    {
        if (currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }
    }

    public void OnStatItemUse(ItemType itemType, float amount)
    {
        upgrade.GetComponent<Upgradeables>();
        Debug.Log("Upgrade" + itemType + " by " + amount);
        switch (itemType)
        {
            case ItemType.FireRate:
                upgrade.UpgradeFireRate(amount);
                break;

            case ItemType.Damage:
                upgrade.UpgradeProjectileDamage(amount);
                break;

            case ItemType.ProjectileSpeed:
                upgrade.UpgradeProjectileSpeed(amount);
                break;
            case ItemType.NumOfProjectiles:
                upgrade.UpgradeNumOfProjectiles(amount);
                break;
            
        }
    }

    public void OnStatItemRemove(ItemType itemType, float amount)
    {
        upgrade.GetComponent<Upgradeables>();
        Debug.Log("Remove " + itemType + " by " + amount);
        switch (itemType)
        {
            case ItemType.FireRate:
                upgrade.RemoveUpgradeFireRate(amount);
                break;

            case ItemType.Damage:
                upgrade.RemoveUpgradeProjectileDamage(amount);
                break;

            case ItemType.ProjectileSpeed:
                upgrade.RemoveUpgradeProjectileSpeed(amount);
                break;
            case ItemType.NumOfProjectiles:
                upgrade.RemoveUpgradeNumOfProjectiles(amount);
                break;

        }
    }

}
