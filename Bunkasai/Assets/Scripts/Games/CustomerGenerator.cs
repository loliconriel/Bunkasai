using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    
    [SerializeField]
    private GameObject SpawnList;
    [SerializeField]
    private GameObject StayList;
    [SerializeField]
    private GameObject[] Customer;
    [SerializeField]
    private float SpawnTime;
    private float Timer;
    private void Start()
    {
        Timer = 0f;
    }
    void Update()
    {
        Timer += Time.deltaTime;
        if (GameManager.StateGame())
        {
            if (Timer-(SpawnTime * Random.Range(0.9f, 1.1f)) > 0)
            {
                
                Timer = 0f;
                Transform SpawnPlace = SpawnList.transform.GetChild(Random.Range(0, 2)).transform;
                var a = Instantiate(Customer[Random.Range(0, Customer.Length)], SpawnPlace);
            }
        }
        
    }

    
}
