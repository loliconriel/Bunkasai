using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    enum Status
    {
        Enter,
        Waitng,
        Leave
    }

    [SerializeField] Vector3 Speed;
    [SerializeField] Vector3 StayPosition;
    [SerializeField] Vector3 EndPosition;

    Status CustomerStatus;

    float LeaveTime = 10f;
    float WaitingTime;

    List<int> DishMoney = new List<int>();
    GameObject OrderPanel;
    public void Init(Vector3 Speed,Vector3 StayPosition,Vector3 EndPosition,List<int> Money)
    {
        this.Speed = Speed;
        this.StayPosition = StayPosition;
        this.EndPosition = EndPosition;
        CustomerStatus = Status.Enter;
        LeaveTime *= GameManager.GetCustomerPassionate();
        WaitingTime = 0f;
        OrderPanel = transform.GetChild(0).gameObject;
        foreach (int i in Money)
        {
            DishMoney.Add((int)(i *GameManager.GetPayAmount()));
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.StateGame())
        {
            if (CustomerStatus == Status.Enter)
            {
                if (Mathf.Abs(transform.position.x - StayPosition.x) < 0.1f)
                {
                    CustomerStatus = Status.Waitng;
                    Order();
                }
                else transform.position += Speed * Time.deltaTime;
            }
            else if (CustomerStatus == Status.Waitng)
            {
                WaitingTime += Time.deltaTime;
                OrderPanel.transform.GetChild(0).GetComponent<Slider>().value = 1 - (WaitingTime / LeaveTime);
                if (WaitingTime > LeaveTime)
                {
                    CustomerStatus = Status.Leave;
                    Leave();
                }
                for (int i = 0; i < transform.GetChild(0).GetChild(1).childCount; i++)
                {
                    if (transform.GetChild(0).GetChild(1).GetChild(i).name != "Success(Clone)")
                    {
                        break;
                    }
                    if (i == transform.GetChild(0).GetChild(1).childCount - 1)
                    {
                        CustomerStatus = Status.Leave;
                        Leave();
                    }
                }
            }
            else
            {
                if (Mathf.Abs(transform.position.x - EndPosition.x) < 0.1f)
                {
                    GameManager.MinusCustomer();
                    Destroy(gameObject);
                }
                else transform.position += Speed * Time.deltaTime;
            }
        }
        
        
        
    }

    private void Order()
    {
        OrderPanel.SetActive(true);
        for (int i = 0; i < transform.GetChild(0).GetChild(1).childCount; i++){
            CustomerOrder.Add(transform.parent.GetSiblingIndex(), DishMoney[i], transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
        }
        
    }
    private void Leave()
    {
        for (int i = 0; i < transform.GetChild(0).GetChild(1).childCount; i++ )
        {
            if (transform.GetChild(0).GetChild(1).GetChild(i).name != "Success(Clone)")
            {
                CustomerOrder.Delete(transform.parent.GetSiblingIndex(), transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
            }
            
        }
        OrderPanel.SetActive(false);
        
       
    }

}
