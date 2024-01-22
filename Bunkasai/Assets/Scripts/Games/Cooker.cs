using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour
{
    private float NowTime;
    private float CookTime;
    private float MuddyTime;
    private bool CookCheck = false;

    public void SetTime(float CookTime, float MuddyTime)
    {
        this.NowTime = 0f;
        this.CookTime = CookTime;
        this.MuddyTime = MuddyTime;
        this.CookCheck = true;
    }
    private void Update()
    {
        if (CookCheck)
        {
            Cooking();
            Dishdetail();
        }
        
    }
    private void Cooking()
    {
        if (CookCheck) {
            NowTime += Time.deltaTime;
            if(NowTime - CookTime - MuddyTime >= 0f)
            {
                CookCheck = false;
            }
        }
        
    }
    private void Dishdetail()
    {
        Debug.Log(NowTime);
    }
}
