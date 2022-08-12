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
        
        ItemChoice.SetActive(false);
    }

    public void ShowItemChoice()
    {
        ItemChoice.SetActive(true);
        ItemChoice.GetComponent<ItemChoice>().ShowItems();
        Debug.Log("Show Items");
    }


    public void DestroyItemChoice()
    {
        ItemChoice.GetComponent<ItemChoice>().DestoryItems();
        ItemChoice.SetActive(false);
    }

}
