using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooker : MonoBehaviour
{
    private float NowTime;
    private float CookTime;
    private float MuddyTime;
    private bool CookCheck = false;
    private GameObject FinalList;
    private GameObject Clock;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(click);
        Clock = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (CookCheck)
        {
            Cooking();
            Dishdetail();
        }
        
    }
    public void SetDish(float CookTime, float MuddyTime,GameObject FinalList)
    {
        this.NowTime = 0f;
        this.CookTime = CookTime;
        this.MuddyTime = MuddyTime;
        this.CookCheck = true;
        this.FinalList = FinalList;
    }
    private void click()
    {
        if(NowTime-CookTime>=0f && NowTime < MuddyTime)
        {

        }
    }
    private void Cooking()
    {
        if (CookCheck) {
            NowTime += Time.deltaTime;
            Clock.GetComponent<Image>().fillAmount = NowTime / CookTime; 
            if(NowTime >= MuddyTime)
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
