using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    Vector3 Speed;
    [SerializeField] Vector3 StayPosition;
    [SerializeField] Vector3 EndPosition;

    public Customer(Vector3 Speed,Vector3 StayPosition,Vector3 EndPosition)
    {
        this.Speed = Speed;
        this.StayPosition = StayPosition;
        this.EndPosition = EndPosition;
        Debug.Log(this.Speed + "  " + this.StayPosition+"  "+this.EndPosition);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
