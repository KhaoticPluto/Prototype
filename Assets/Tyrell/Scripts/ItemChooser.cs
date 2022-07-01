using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChooser : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    public Item item;

    public Image icon;

    public GameManager manager;
    

    private void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        
        Item newItem = itemList[Random.Range(0, itemList.Count)];
        AddItem(newItem);
        Debug.Log("Didnt work");
    }

    public void AddItem(Item newItem)
    {
        Debug.Log("New Item");
        item = newItem;
        icon.GetComponent<Image>().sprite = newItem.icon;
        
    }

    public void OnCursorEnter()
    {
        if (item == null) return;

        //display item info
        GameManager.instance.DisplayItemInfo(item.name, item.GetItemDescription(), transform.position);
    }

    public void OnCursorExit()
    {
        if (item == null) return;

        GameManager.instance.DestroyItemInfo();
    }

    public void PutInInventory()
    {
        Inventory.instance.AddItem(Instantiate(item));
        
    }

    public void ClearItemChoice()
    {
        manager.GetComponent<GameManager>();
        manager.DestroyItemChoice();
    }

}
