using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drink : Ingredient
{
    enum Status
    {
        Make,
        Idle
    }
    [SerializeField]
    private float CookTime;
    private float ReadyTime;
    private float NowTime;
    private Image Clock;
    private Status status;
    void Awake()
    {
        status = Status.Idle;
        Clock = transform.GetChild(0).GetComponent<Image>();
        Clock.color = Color.green;
        Clock.fillAmount = 0f;

        NowTime = 0f;
        GetComponent<Button>().onClick.AddListener(action);
    }

    void Init()
    {
        status = Status.Idle;
        Clock.color = Color.green;
        Clock.fillAmount = 0f;
        NowTime = 0f;
        ReadyTime = CookTime * GameManager.GetDishCookTime();
    }
    private void Update()
    {
        if (GameManager.StateGame())
        {
            if (status == Status.Make)
            {
                NowTime += Time.deltaTime;
                Clock.fillAmount = NowTime / ReadyTime;
            }
        }
        
    }
    protected override void action()
    {
        if(status == Status.Idle)
        {
            Init();
            //Instantiate(Content, transform);
            status = Status.Make;
        }
        else
        {
            if (NowTime >= ReadyTime)
            {
                foreach (Transform item in FinalList.transform)
                {
                    if (item.childCount <= 0)
                    {
                        Instantiate(Content, item.transform);
                        Init();
                        break;
                    }
                }
            }
        }
    }
}