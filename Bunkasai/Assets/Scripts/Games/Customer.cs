using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    float LeaveTime = 3f;
    float WaitingTime;

    public void Init(Vector3 Speed,Vector3 StayPosition,Vector3 EndPosition)
    {
        this.Speed = Speed;
        this.StayPosition = StayPosition;
        this.EndPosition = EndPosition;
        CustomerStatus = Status.Enter;
        WaitingTime = 0f;
        
    
    }

    // Update is called once per frame
    void Update()
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
        else if(CustomerStatus == Status.Waitng)
        {
            WaitingTime += Time.deltaTime;
            if (WaitingTime > LeaveTime)
            {
                CustomerStatus = Status.Leave;
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - EndPosition.x) < 0.1f)
            {
                Destroy(gameObject);
            }
            else transform.position += Speed * Time.deltaTime;

        }
        
        
    }
    private void Order()
    {

    }


}
