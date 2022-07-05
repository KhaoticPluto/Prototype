using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    #region singleton
    public static MoneyManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    public static int Money = 0;

    private void Update()
    {
        if(Money < 0)
        {
            Money = 0;
        }
    }

    public void GainMoney(int Amount)
    {
        Money += Amount;
    }
}
