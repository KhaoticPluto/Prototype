using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PerkCounter : MonoBehaviour
{
    public TextMeshProUGUI perkIncrease;

    int perks = 0;

    private void Start()
    {
        perkIncrease.text = perks.ToString();
    }
}
