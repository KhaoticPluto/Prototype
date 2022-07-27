using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItems : MonoBehaviour
{
    #region singleton
    public static ShowItems instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public GameObject ItemChoice;

    private void Start()
    {
        ItemChoice = GameObject.FindWithTag("ItemChoice");
        Debug.Log("ShowItems found " + ItemChoice);
        ItemChoice.SetActive(false);
    }

    public void ShowItemChoice()
    {
        ItemChoice.SetActive(true);
        ItemChoice.GetComponent<ItemChoice>().ShowItems();
        
    }

    public void DestroyItemChoice()
    {
        ItemChoice.GetComponent<ItemChoice>().DestoryItems();
        ItemChoice.SetActive(false);

    }

}
