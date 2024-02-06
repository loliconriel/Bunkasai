using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro.Examples;
using Unity.VisualScripting;
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
    [SerializeField]
    private List<int> ToppingMoney;
    
    private float Timer;
    private void Start()
    {
        Timer = 0f;
    }
    void Update()
    {
        
        if (GameManager.StateGame()&&GameManager.RoundEnd()!=true )
        {
            Timer += Time.deltaTime;
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
                    GameObject SpawnCustomer = Instantiate(Customer[Random.Range(0, Customer.Length)], SpawnPlace);
                    SpawnCustomer.transform.SetParent(StayList.transform.GetChild(Spawnindex));
                    Customer CustomerInit = SpawnCustomer.AddComponent<Customer>();
                    GameManager.AddCustomer();
                     
                    Vector3 Speed =  new Vector3((StayList.transform.GetChild(1).position.x - StayList.transform.GetChild(0).position.x) /1.5f,0f,0f)*GameManager.GetCustomerSpeed();
                    List<int> Money = new List<int>();
                    Money = GenerateOrder(SpawnCustomer.transform.GetChild(0).GetChild(1).gameObject);
                    if (Spawnnumber == 0)
                    {
                        CustomerInit.Init(Speed, SpawnCustomer.transform.parent.position, SpawnList.transform.GetChild(1).position,Money);
                    }
                    else CustomerInit.Init(-Speed, SpawnCustomer.transform.parent.position, SpawnList.transform.GetChild(0).position,Money);
                }
                
            }
        }
        else
        {
            Timer = 0f;
        }
    } 

    private List<int> GenerateOrder(GameObject OrderList)
    {

        int FirstDish = Random.Range(0, 2);
        List<int> Money = new List<int>();
        int FirstDishMoney;
        GameObject Dish1;
        if (FirstDish == 0)
        {
            Dish1 = Instantiate(Dish[Random.Range(0, Dish.Count)],OrderList.transform);
            FirstDishMoney = 50;
            foreach (GameObject Topping in DishTopping)
            {
                if (Random.Range(0, 2) == 1) {
                    FirstDishMoney += ToppingMoney[DishTopping.IndexOf(Topping)];
                    Instantiate(Topping, Dish1.transform);
                }
            }
            
        }
        else
        {
            int DrinkType = Random.Range(0, Drink.Count);
            Dish1 = Instantiate(Drink[DrinkType], OrderList.transform);
            FirstDishMoney = 15 + (DrinkType + 1) * 5;
            foreach (GameObject Topping in DrinkTopping)
            {
                if (Random.Range(0, 2) == 1)
                {
                    FirstDishMoney += (DrinkTopping.IndexOf(Topping) + 1) * 5;
                    Instantiate(Topping, Dish1.transform);
                }
            }
            
        }
        Money.Add(FirstDishMoney);
        if (Random.Range(0, 2) == 1)
        {
            GameObject Dish2;
            int SecondDishMoney;
            if(FirstDish == 0)
            {
                int DrinkType = Random.Range(0, Drink.Count);
                Dish2 = Instantiate(Drink[DrinkType], OrderList.transform);
                SecondDishMoney = 15 + (DrinkType + 1) * 5;
                foreach (GameObject Topping in DrinkTopping)
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        SecondDishMoney += ((DrinkTopping.IndexOf(Topping) + 1) * 5);
                        Instantiate(Topping, Dish2.transform);
                    }
                }
            }
            else
            {
                Dish2 = Instantiate(Dish[Random.Range(0, Dish.Count)], OrderList.transform);
                SecondDishMoney = 50;
                foreach (GameObject Topping in DishTopping)
                {
                    if (Random.Range(0, 2) == 1) {
                        SecondDishMoney += ToppingMoney[DishTopping.IndexOf(Topping)];
                        Instantiate(Topping, Dish2.transform);
                    } 
                }
            }
            Money.Add(SecondDishMoney);
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
        return Money;
    }
    
}
