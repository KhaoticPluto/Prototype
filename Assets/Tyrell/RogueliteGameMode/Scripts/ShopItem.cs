using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{

    public int ItemCost;

    public TextMeshProUGUI CostText;
    public TextMeshProUGUI ItemNameText;

    public ItemDrop item;
    public RandomShopItem ChoseItem;
    // Start is called before the first frame update
    void Start()
    {
        item = ChoseItem.ChoseItemList[Random.Range(0, ChoseItem.ChoseItemList.Count)];
        ItemCost = item.ItemCost;

        CostText.text = ItemCost + "";
        ItemNameText.text = item.name;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            BuyItem();
        }
    }


    public void BuyItem()
    {
        if (MoneyManager.Money >= ItemCost)
        {
            MoneyManager.Money -= ItemCost;
            item.Use();
            ChoseItem.RemoveFromList(item);

        }
        else
        {
            Debug.Log("Cant Afford");
        }

    }
}
