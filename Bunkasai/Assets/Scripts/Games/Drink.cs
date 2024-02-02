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
    private float CookTime = 5f;
    private float NowTime;
    private Image Clock;
    private Status status;
    private void Awake()
    {

        status = Status.Idle;
        Clock = transform.GetChild(0).GetComponent<Image>();
        Clock.color = Color.green;
        Clock.fillAmount = 0f;
        CookTime *= GameManager.GetDishCookTime();
        NowTime = 0f;
        GetComponent<Button>().onClick.AddListener(action);
    }
    void Init()
    {
        status = Status.Idle;
        Clock.color = Color.green;
        Clock.fillAmount = 0f;
        NowTime = 0f;
    }
    private void Update()
    {
        if (GameManager.StateGame())
        {
            if (status == Status.Make)
            {
                NowTime += Time.deltaTime;
                Clock.fillAmount = NowTime / CookTime;
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
            if (NowTime >= CookTime)
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
