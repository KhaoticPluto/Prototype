using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class WardenBossManager : MonoBehaviour
{
    public GameObject WardenBoss;

    GameObject InstanceBoss;

    public TextMeshProUGUI WardenName;
    public Slider WardenHealthBar;

    public float Health = 100;
    public float MaxHealth = 100;

    private void Start()
    {
        StartCoroutine(SpawnBoss());
    }

    private void Update()
    {
        WardenHealthBar.value = CalculateHealth();

        if(Health <= 0)
        {
            DestroyWardenBoss();
            LoadSceneManager.instance.LoadStartingArea();
        }
    }

    IEnumerator SpawnBoss()
    {


        yield return new WaitForSeconds(5f);

        InstanceBoss = Instantiate(WardenBoss, transform.position, Quaternion.identity, this.transform);
        InstanceBoss.GetComponent<BossHealth>().healthManager = this;

    }

    

    public void DestroyWardenBoss()
    {
        Destroy(InstanceBoss);
    }

    float CalculateHealth()
    {
        return Health / MaxHealth;
    }
}
