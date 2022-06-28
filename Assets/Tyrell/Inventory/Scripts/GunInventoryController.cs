using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInventoryController : MonoBehaviour
{
    public int GunInventorySlotSize => gameObject.transform.childCount;
    private List<ItemSlot> GunInventorySlots = new List<ItemSlot>();

    


    private void Start()
    {
        SetUpGunInventorySlots();
        Inventory.instance.onItemChange += UpdateGunInventoryUI;
    }

    private void Update()
    {
        
    }

    private void UpdateGunInventoryUI()
    {
        int currentUsedSlotCount = Inventory.instance.GunInventoryItemList.Count;
        for (int i = 0; i < GunInventorySlotSize; i++)
        {
            if (i < currentUsedSlotCount)
            {
                GunInventorySlots[i].AddItem(Inventory.instance.GunInventoryItemList[i]);
                
            }
            else
            {
                GunInventorySlots[i].ClearSlot();
                
            }
        }

    }

    private void SetUpGunInventorySlots()
    {
        for (int i = 0; i < GunInventorySlotSize; i++)
        {
            ItemSlot slot = gameObject.transform.GetChild(i).GetComponent<ItemSlot>();
            GunInventorySlots.Add(slot);
        }
    }
}
