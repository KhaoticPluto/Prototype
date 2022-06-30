using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Item/baseItem")]
public class Item : ScriptableObject
{
    new public string name = "Defulat Item";
    public Sprite icon = null;
    public string itemDescription = "Used for projectile";

    public ItemType itemType;
    public float amount;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
        GameManager.instance.OnStatItemUse(itemType, amount);
    }

    public virtual void Remove()
    {
        Debug.Log("Removing " + name);
        GameManager.instance.OnStatItemRemove(itemType, amount);
    }

    public virtual string GetItemDescription()
    {
        return itemDescription;
    }

    

}

public enum ItemType
{
    FireRate,
    Damage,
    ProjectileSpeed,
    NumOfProjectiles
}
