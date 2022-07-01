using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChoice : MonoBehaviour
{

    public ItemChooser Items;

    public List<ItemChooser> itemChoiceList = new List<ItemChooser>();

    private void Update()
    {
        itemChoiceList.RemoveAll(GameObject => GameObject == null);
    }

    public void EndOfWave()
    {
        for(int i = 0; i < 3; i++)
        {
            SpawnItems();
        }
    }


    void SpawnItems()
    {
        itemChoiceList.Add(Instantiate(Items, this.transform.transform));
        
    }

   public void DestoryItems()
    {
        foreach(ItemChooser items in itemChoiceList)
        {
            Destroy(items.gameObject);
            
        }
        

    }

}
