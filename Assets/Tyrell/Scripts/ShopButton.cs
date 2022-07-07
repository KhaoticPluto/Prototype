using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopButton : MonoBehaviour
{
    public int ItemCost;
    
    public TextMeshProUGUI CostText;

    public ItemDrop item;
    

    void Start()
    {
        
    }


    void Update()
    {
        CostText.text = ItemCost.ToString();
    }

    public void BuyItem()
    {
        if(MoneyManager.Money >= ItemCost)
        {
            MoneyManager.Money -= ItemCost;
            item.Use();
            ItemCost = Mathf.RoundToInt(ItemCost * 1.25f);
            
        }
        else
        {
            Debug.Log("Cant Afford");
        }
        
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
}