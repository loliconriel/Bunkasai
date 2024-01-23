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
    private GameObject Content;
    private GameObject TargetList;
    private Image Clock;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(click);
        Clock = transform.GetChild(0).GetComponent<Image>();
        Clock.color = Color.green;
        Clock.fillAmount = 0f;
    }

    private void Update()
    {
        if (CookCheck)
        {
            Cooking();
            Dishdetail();
        }
        
    }
    public void SetDish(float CookTime, float MuddyTime,GameObject Content,GameObject TargetList)
    {
        this.NowTime = 0f;
        this.CookTime = CookTime;
        this.MuddyTime = MuddyTime;
        this.CookCheck = true;
        this.Content = Content;
        this.TargetList = TargetList;
        Clock.color = Color.green;
        Clock.fillAmount = 0f;
        
    }
    private void click()
    {
        if (CookCheck)
        {
            if (NowTime - CookTime >= 0f && NowTime < MuddyTime)
            {
                foreach (Transform item in TargetList.transform)
                {
                    if (item.childCount == 0)
                    {
                        Instantiate(Content, item.transform);
                        Destroy(transform.GetChild(1).gameObject);
                        Clock.fillAmount = 0f;
                        CookCheck = false;
                        Debug.Log("Sent Success");
                        break;
                    }
                }
                Debug.Log("Ready");
            }
            else
            {
                Debug.Log("Not ready yet");
            }
        }
        else
        {
            Debug.Log("Nothing is Cooking");
        }
    }
    public void DoubleClick()
    {
        if(transform.childCount > 1)
        {
            if (NowTime > MuddyTime)
            {
                Destroy(transform.GetChild(1).gameObject);
                Debug.Log("Sent to trash");
            }
        }
       
    }
    private void Cooking()
    {
        NowTime += Time.deltaTime;

        if (NowTime > MuddyTime)
        {
            CookCheck = false;
            Clock.fillAmount = 0f;
            
        }
        else if (NowTime >= CookTime)
        {
            Clock.fillAmount = (NowTime - CookTime) / (MuddyTime - CookTime);
            Clock.color = Color.red;
        }
        else
        {
            Clock.fillAmount = NowTime / CookTime;
        }

    }
    private void Dishdetail()
    {
        //Debug.Log(NowTime);
    }
}
