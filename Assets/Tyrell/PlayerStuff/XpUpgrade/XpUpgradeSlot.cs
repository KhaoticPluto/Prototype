using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XpUpgradeSlot : ItemSlot
{
    public LevelSystem levelStats;
    public GameObject CantAffordText;

    private void Start()
    {
        levelStats = FindObjectOfType<LevelSystem>();
    }
    public void UpgradeItem()
    {
        if(levelStats.EXPpoints > 0 && item.level < item.maxLevel)
        {
            Item.Upgrade();
            Item.UpdateUpgrade();
            levelStats.EXPpoints--;
        }
        else if(item.level == item.maxLevel)
        {
            StartCoroutine(CantAfford("Maxed level"));
        }
        else
        {
            StartCoroutine(CantAfford("No Exp Points"));
        }
        
    }

    IEnumerator CantAfford(string description)
    {
        CantAffordText.GetComponent<TextMeshProUGUI>().text = description;
        CantAffordText.SetActive(true);
        //CantAffordText.GetComponent<TextMeshProUGUI>().faceColor = new Color(28, 255, 23, 0);
        yield return new WaitForSeconds(0.5f);

        CantAffordText.SetActive(false);
    }

    public override void OnCursorEnter()
    {
        if (item == null || isBeingDraged == true) return;

        //display item info
        GameManager.instance.DisplayItemInfo(item.name, item.GetItemUpgradeDescription(), transform.position);
    }

    public override void OnCursorExit()
    {
        if (item == null) return;

        GameManager.instance.DestroyItemInfo();
    }
}
