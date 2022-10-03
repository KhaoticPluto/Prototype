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

    public CanvasGroup thisCanvas;
    public GameObject HUD;
    public GameObject BG;


    private List<ItemSlot> itemSlotList = new List<ItemSlot>();

    public GameObject inventorySlotPrefab;
    
    public Transform invetoryItemTransform;



    private void Start()
    {
        CloseInventory();
        HUD = GameObject.FindWithTag("HUD"); 

        Inventory.instance.onItemChange += UpdateInventoryUI;

    }


    // Update is called once per frame
    void Update()
    {
        UpdateInventoryUI();
        Inventory.instance.onItemChange += UpdateInventoryUI;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //checks if game is paused or not before allowing the inventory to open
            if (inventoryOpen)
            {
                //close inventory
                CloseInventory();
                GameManager.instance.DestroyItemInfo();
                
            }
            else
            {
                if(HUDManager.isPaused == false)
                {
                    //openInventory
                    OpenInventory();
                    
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


    public void OpenInventory()
    {
        inventoryOpen = true;
        //BG.SetActive(true);
        thisCanvas.alpha = 1;
        thisCanvas.blocksRaycasts = true;
        thisCanvas.interactable = true;

        HUD.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseInventory()
    {
        inventoryOpen = false;
        //BG.SetActive(false);
        thisCanvas.alpha = 0;
        thisCanvas.blocksRaycasts = false;
        thisCanvas.interactable = false;

        HUD.SetActive(true);
        Time.timeScale = 1;
    }


}
