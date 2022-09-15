using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIHandler : MonoBehaviour
{
    #region singleton
    public static InventoryUIHandler instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public bool inventoryOpen = false;
    public bool InventoryOpen => inventoryOpen;
    public GameObject inventoryParent;
    public GameObject GunInventory;
    public GameObject playerStats;
    public GameObject SetBonus;
    public GameObject Border;
    public GameObject HUD;
    public GameObject BG;


    private List<ItemSlot> itemSlotList = new List<ItemSlot>();

    public GameObject inventorySlotPrefab;
    
    public Transform invetoryItemTransform;



    private void Start()
    {
        HUD = FindObjectOfType<HUDManager>().gameObject;

        Inventory.instance.onItemChange += UpdateInventoryUI;
        UpdateInventoryUI();

        OpenInventory();
        StartCoroutine(CloseTheInventory());
    }

    IEnumerator CloseTheInventory()
    {
        yield return new WaitForSeconds(.05f);
        CloseInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //checks if game is paused or not before allowing the inventory to open
            if (inventoryOpen)
            {
                //close inventory
                CloseInventory();
                GameManager.instance.DestroyItemInfo();
                Time.timeScale = 1;
            }
            else
            {
                if(HUDManager.isPaused == false)
                {
                    //openInventory
                    OpenInventory();
                    Time.timeScale = 0;
                }
                
            }
        }
    }


    private void UpdateInventoryUI()
    {
        int currentItemCount = Inventory.instance.inventoryItemList.Count;

        if (currentItemCount > itemSlotList.Count)
        {
            //Add more item slots
            AddItemSlots(currentItemCount);
        }

        for (int i = 0; i < itemSlotList.Count; ++i)
        {
            if (i < currentItemCount)
            {
                //update the current item in the slot
                itemSlotList[i].AddItem(Inventory.instance.inventoryItemList[i]);
            }
            else
            {
                itemSlotList[i].DestroySlot();
                itemSlotList.RemoveAt(i);
            }
        }
    }

    private void AddItemSlots(int currentItemCount)
    {
        int amount = currentItemCount - itemSlotList.Count;

        for (int i = 0; i < amount; ++i)
        {
            GameObject GO = Instantiate(inventorySlotPrefab, invetoryItemTransform);
            ItemSlot newSlot = GO.GetComponent<ItemSlot>();
            itemSlotList.Add(newSlot);
        }
    }


    private void OpenInventory()
    {
        inventoryOpen = true;
        BG.SetActive(true);
        inventoryParent.SetActive(true);
        GunInventory.SetActive(true);
        playerStats.SetActive(true);
        SetBonus.SetActive(true);
        Border.SetActive(true);

        HUD.SetActive(false);
    }

    public void CloseInventory()
    {
        inventoryOpen = false;
        BG.SetActive(false);
        inventoryParent.SetActive(false);
        GunInventory.SetActive(false);
        playerStats.SetActive(false);
        Border.SetActive(false);
        SetBonus.SetActive(false);

        HUD.SetActive(true);
    }


}
