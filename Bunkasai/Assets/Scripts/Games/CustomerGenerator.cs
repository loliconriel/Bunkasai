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
    [SerializeField]
    private List<GameObject> Dish;
    [SerializeField]
    private List<GameObject> DishTopping;
    [SerializeField]
    private List<GameObject> Drink;
    [SerializeField]
    private List<GameObject> DrinkTopping;
    
    private float Timer;
    private void Start()
    {
        Timer = 0f;
    }
    void Update()
    {
        Timer += Time.deltaTime;
        if (GameManager.StateGame()&&GameManager.RoundEnd()!=true )
        {
            if (Timer-(SpawnTime* GameManager.GetCustomerVisitSpeed() * Random.Range(0.9f, 1.1f)) > 0)
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
                    int Spawnindex;
                    do Spawnindex = Random.Range(0, StayList.transform.childCount); while (StayList.transform.GetChild(Spawnindex).childCount != 0);

                    Transform SpawnPlace = SpawnList.transform.GetChild(Spawnnumber).transform;
                    GameObject a = Instantiate(Customer[Random.Range(0, Customer.Length)], SpawnPlace);
                    a.transform.SetParent(StayList.transform.GetChild(Spawnindex));
                    Customer test = a.AddComponent<Customer>();

                    Vector3 Speed =  new Vector3((StayList.transform.GetChild(1).position.x - StayList.transform.GetChild(0).position.x) /1.5f,0f,0f)*GameManager.GetCustomerSpeed();
                    Order(a.transform.GetChild(0).GetChild(1).gameObject);
                    if (Spawnnumber == 0)
                    {
                        test.Init(Speed, a.transform.parent.position, SpawnList.transform.GetChild(1).position);
                    }
                    else test.Init(-Speed, a.transform.parent.position, SpawnList.transform.GetChild(0).position);
                }
                
            }
        }
        
    }
    private void Order(GameObject OrderList)
    {

        int FirstDish = Random.Range(0, 2);
        GameObject Dish1;
        if (FirstDish == 0)
        {
            Dish1 = Instantiate(Dish[Random.Range(0, Dish.Count)],OrderList.transform);
            foreach (GameObject Topping in DishTopping)
            {
                if (Random.Range(0, 2) == 1) Instantiate(Topping,Dish1.transform);
            }
        }
        else
        {
            Dish1 = Instantiate(Drink[Random.Range(0, Drink.Count)], OrderList.transform);
        }
        if (Random.Range(0, 2) == 1)
        {
            GameObject Dish2;
            if(FirstDish == 0)
            {
                Dish2 = Instantiate(Drink[Random.Range(0, Drink.Count)], OrderList.transform);
            }
            else
            {
                Dish2 = Instantiate(Dish[Random.Range(0, Dish.Count)], OrderList.transform);
                foreach (GameObject Topping in DishTopping)
                {
                    if (Random.Range(0, 2) == 1) Instantiate(Topping, Dish2.transform);
                }
            }
            Dish1.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, 0.1f);
            Dish1.GetComponent<RectTransform>().anchorMax = new Vector2(0.9f, 0.4f);
            Dish2.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, 0.5f);
            Dish2.GetComponent<RectTransform>().anchorMax = new Vector2(0.9f, 0.9f);

        }
        else
        {
            Dish1.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, 0.1f);
            Dish1.GetComponent<RectTransform>().anchorMax = new Vector2(0.9f, 0.9f);
        }
        
    }
    
}
