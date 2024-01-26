using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    Vector3 StartPosition;
    Vector3 StayPosition;
    Vector3 EndPosition;

    public Customer(Vector3 StayPosition,Vector3 EndPosition)
    {
        this.StayPosition = StayPosition;
        this.EndPosition = EndPosition;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CustomerInit()
    {

    }


}
