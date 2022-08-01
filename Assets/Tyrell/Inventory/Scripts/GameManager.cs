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

    

    public List<Item> WaveitemList = new List<Item>();
    public List<Item> RogueItemList = new List<Item>();
    
    
    public GameObject itemInfoPrefab;
    private GameObject currentItemInfo = null;

    public Transform mainCanvas;
    public Transform GunInventoryTransform;
    public Transform inventoryTransform;

    public float moveX;
    public float moveY;

    

    

    private void Start()
    {
        Time.timeScale = 1;

        
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Item newItem = WaveitemList[Random.Range(0, WaveitemList.Count)];

            Inventory.instance.AddItem(Instantiate(newItem));
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Item newItem = RogueItemList[Random.Range(0, RogueItemList.Count)];

            Inventory.instance.AddItem(Instantiate(newItem));
        }

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

    
}
