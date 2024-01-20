using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    
    private float NowTime = 0f;
    [SerializeField]
    private float CookTime = 10f;
    [SerializeField]
    private float MuddyTime = 10f;
    private bool CookCheck = true;
    private void Update()
    {
        Cooking();
        Dishdetail();
    }
    protected virtual void Cooking()
    {
        if (CookCheck) NowTime+=Time.deltaTime;
    }
    protected virtual void Dishdetail()
    {
        //Debug.Log(NowTime);
    }
}
