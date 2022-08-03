using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomShopItem : MonoBehaviour
{

    
    public List<ItemDrop> ChoseItemList = new List<ItemDrop>();

    public void RemoveFromList(ItemDrop item)
    {
        ChoseItemList.Remove(item);
    }

}
