using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField]
    GameObject Success;
    public static CustomerOrder instance;
    private List<GameObject> Orders = new List<GameObject>();
    private List<int> Customers = new List<int>();
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        //Debug.Log(Orders.Count + " " + Customers.Count);
    }
    public static void Add(int CustomerNumber,GameObject Dish)
    {
        instance.Orders.Add(Dish);

        instance.Customers.Add(CustomerNumber);
    }
    public static void Delete(int CustomerNumber,GameObject Dish)
    {
        for (int i = 0; i < instance.Customers.Count; i++)
        {
            if (instance.Customers[i] == CustomerNumber)
            {
                if (instance.Orders[i].name == Dish.name)
                {
                    instance.Customers.RemoveAt(i);
                    instance.Orders.RemoveAt(i);
                    break;
                }
            }
            
            
        }
    }
    public static bool Compare(GameObject Dish)
    {
        for (int i = 0; i < instance.Orders.Count; i++)
        {
            if (instance.Orders[i].name == Dish.name)
            {
                if (instance.Orders[i].transform.childCount == Dish.transform.childCount)
                {
                    bool check = true;
                    foreach(Transform Topping in instance.Orders[i].transform)
                    {
                        if(Topping.name != Dish.transform.GetChild(Topping.GetSiblingIndex()).name){
                            check = false;
                        }
                    }
                    if (check)
                    {
                        GameObject a = instance.transform.GetChild(1).GetChild(instance.Customers[i]).GetChild(0).GetChild(0).GetChild(1).gameObject;

                        for (int j = 0; j < a.transform.childCount; j++)
                        {
                            if (a.transform.GetChild(j).name == Dish.name)
                            {
                                GameObject SuccessImage = Instantiate(instance.Success, a.transform);
                                SuccessImage.GetComponent<RectTransform>().anchorMin = a.transform.GetChild(j).GetComponent<RectTransform>().anchorMin;
                                SuccessImage.GetComponent<RectTransform>().anchorMax = a.transform.GetChild(j).GetComponent<RectTransform>().anchorMax;
                                Destroy(a.transform.GetChild(j).gameObject);
                                
                                break;
                            }
                        }
                        Delete(instance.Customers[i], instance.Orders[i]);
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        return false;
    }
}
