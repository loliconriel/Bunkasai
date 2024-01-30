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
                int Spawnnumber = Random.Range(0, 1);
                Transform SpawnPlace = SpawnList.transform.GetChild(Spawnnumber).transform;
                GameObject a = Instantiate(Customer[Random.Range(0, Customer.Length)], SpawnPlace);
                a.transform.SetParent(StayList.transform.GetChild(Random.Range(0, StayList.transform.childCount)));
                Vector3 Speed = StayList.transform.GetChild(1).localPosition - StayList.transform.GetChild(0).localPosition;
                //test = Spawnnumber == 0 ? new Customer(Speed, transform.parent.localPosition, SpawnList.transform.GetChild(1).localPosition) : new Customer(-Speed, transform.parent.localPosition, SpawnList.transform.GetChild(0).localPosition);
                
            }
        }
        
    }

    
}
