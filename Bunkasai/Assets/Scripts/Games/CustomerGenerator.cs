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
                int counter = 0;
                Timer = 0f;
                for (int i = 0; i < StayList.transform.childCount; i++)
                {
                    if (StayList.transform.GetChild(i).childCount != 0)
                    {
                        counter++;
                    }
                    else break;
                }
                if(counter != StayList.transform.childCount)
                {
                    int Spawnnumber = Random.Range(0, 2);
                    int Spawnplace;
                    do
                    {
                        Spawnplace = Random.Range(0, StayList.transform.childCount);
                    } while (StayList.transform.GetChild(Spawnplace).childCount != 0);
                    Transform SpawnPlace = SpawnList.transform.GetChild(Spawnnumber).transform;
                    GameObject a = Instantiate(Customer[Random.Range(0, Customer.Length)], SpawnPlace);
                    a.transform.SetParent(StayList.transform.GetChild(Spawnplace));
                    Customer test = a.AddComponent<Customer>();
                    Vector3 Speed = StayList.transform.GetChild(1).localPosition - StayList.transform.GetChild(0).localPosition;
                    if (Spawnnumber == 0)
                    {
                        test.Init(Speed, transform.parent.localPosition, SpawnList.transform.GetChild(1).localPosition);
                    }
                    else test.Init(-Speed, transform.parent.localPosition, SpawnList.transform.GetChild(0).localPosition);
                }
                else
                {
                    
                }
                
            }
        }
        
    }

    
}
