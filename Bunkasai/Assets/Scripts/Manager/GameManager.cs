using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    [SerializeField]
    private string GamingScene;
    [SerializeField]
    private float TotalTime;
    private float RemainTime;
    private bool GamePlayCheck;
    private bool GamePlayEnd;

    private int NowMoney = 0;
    private int CurrentRound = 0;
    private int TotalRound = 1;
    private int TargetMoney = 1000;
    private int[] UpgradeList = new int[8] {1,1,1,1,1,1,-1,-1};
    private float CustomerVisitSpeed = 1f;
    private float CustomerPassionate = 1f;
    private float PayAmount = 1f;
    private float CustomerSpeed = 1f;
    private float DishCookTime = 1f;
    private float DishMuddyTime = 1f;

    private int NowCustomer = 0;
    private GameObject ShopPanel;
    private GameObject EndPanel;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        RemainTime = TotalTime;

        //if (SceneManager.GetActiveScene().name == GamingScene.name) GamePlayCheck = true;
        //else GamePlayCheck = false;
        GamePlayCheck = false;
        GamePlayEnd = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlayCheck)
        {
            RemainTime -= Time.deltaTime;
            if (RemainTime <= 0f)
            {
                GamePlayEnd = true;
            }
            if(NowCustomer == 0 && GamePlayEnd)
            {
                GamePlayCheck = false;
                if(instance.CurrentRound+1 < instance.TotalRound)
                {
                    ShopPanel.SetActive(true);
                    MusicPlayer.DestoryEffect();
                }
                else
                {
                    EndPanel.SetActive(true);
                    Debug.Log("Game End!");
                }
                
            }
        }
    }
    public static void GameSetting(int Difficulty)
    {
        switch (Difficulty)
        {

            case 0:
                GameSet(new int[8] { 1, 2, 2, 2, 2, 3, -1, -1 },1, 1000, 1.5f, 1f, 1.5f, 1.2f, 0.5f, 1.5f);
                break;
            case 1:
                GameSet(new int[8] { 1, 1, 1, 1, 1, 2, -1, -1 },3, 4000, 1f, 1f, 1f, 1f, 1f, 1f);
                break;
            case 2:
                GameSet(6, 10000, 0.8f, 1.3f, 0.8f, 0.8f, 1.2f, 0.8f);
                break;
            case 3:
                GameSet(6, 10000, 0.8f, 1.3f, 0.8f, 0.8f, 1.2f, 0.8f);
                break;
        }
    }
    private static void GameSet(int[] UpgradeList,int TotalRound = 1, int TargetMoney = 1000, float CustomerPassionate = 1.5f, float CustomerVisitSpeed = 1f, float PayAmount = 1.5f, float CustomerSpeed = 1.2f, float DishCookTime = 0.5f, float DishMuddyTime = 1.5f)
    {
        instance.NowMoney = 100;
        instance.CurrentRound = 0;
        instance.NowCustomer = 0;
        instance.TotalRound = TotalRound;
        instance.TargetMoney = TargetMoney;
        instance.CustomerPassionate = CustomerPassionate;
        instance.CustomerVisitSpeed = CustomerVisitSpeed;
        instance.PayAmount = PayAmount;
        instance.CustomerSpeed = CustomerSpeed;
        instance.DishCookTime = DishCookTime;
        instance.DishMuddyTime = DishMuddyTime;

        instance.UpgradeList = (int[])UpgradeList.Clone();
    }
    private static void GameSet(int TotalRound = 1, int TargetMoney = 1000, float CustomerPassionate = 1.5f, float CustomerVisitSpeed = 1f, float PayAmount = 1.5f, float CustomerSpeed = 1.2f, float DishCookTime = 0.5f, float DishMuddyTime = 1.5f)
    {
        instance.NowMoney = 100;
        instance.CurrentRound = 0; 
        instance.TotalRound = TotalRound;
        instance.TargetMoney = TargetMoney;
        instance.CustomerPassionate = CustomerPassionate;
        instance.CustomerVisitSpeed = CustomerVisitSpeed;
        instance.PayAmount = PayAmount;
        instance.CustomerSpeed = CustomerSpeed;
        instance.DishCookTime = DishCookTime;
        instance.DishMuddyTime = DishMuddyTime;
        for(int i = 0; i < instance.UpgradeList.Length; i++)
        {
            instance.UpgradeList[i] = 0;
        }
        instance.UpgradeList[6] = -1;
        instance.UpgradeList[7] = -1;
    }
    public static void GameInit(float TotalTime)
    {
        instance.TotalTime = TotalTime;
    }
    public static void Init()
    {
        instance.RemainTime = instance.TotalTime;
        instance.GamePlayEnd = false;
    }
    public static float GetRemainTime()
    {
        return instance.RemainTime/instance.TotalTime;
    }
    public static bool RoundEnd()
    {
        return instance.GamePlayEnd;
    }
    public static bool StateGame()
    {
        return instance.GamePlayCheck;
    }
    public static void PauseGame()
    {
        instance.GamePlayCheck = false;
    }
    public static void StartGame()
    {
        instance.GamePlayCheck = true;
    }
    public static void AddMoney(int money)
    {
        instance.NowMoney += money;
    }
    public static void MinusMoney(int money)
    {
        instance.NowMoney -= money;
    }
    public static void AddCurrentRound()
    {
        instance.CurrentRound++;
    }
    public static int GetCurrentRound()
    {
        return instance.CurrentRound;
    }
    public static void AddCustomer()
    {
        instance.NowCustomer++;
    }
    public static void MinusCustomer()
    {
        instance.NowCustomer--;
    }
    public static int GetCustomer()
    {
        return instance.NowCustomer;
    }
    public static int GetMoeny()
    {
        return instance.NowMoney;
    }
    public static int GetTargetMoney()
    {
        return instance.TargetMoney;
    }
    public static void Upgrade(int index)
    {
        instance.UpgradeList[index]++;
    }
    public static int GetUpgrade(int index)
    {
        return instance.UpgradeList[index];
    }
    public static float GetCustomerPassionate()
    {
        return instance.CustomerPassionate;
    }
    public static float GetCustomerVisitSpeed()
    {
        return instance.CustomerVisitSpeed;
    }
    public static float GetPayAmount()
    {
        return instance.PayAmount;
    }
    public static float GetCustomerSpeed()
    {
        return instance.CustomerSpeed;
    }
    public static float GetDishCookTime()
    {
        return instance.DishCookTime;
    }
    public static float GetDishMuddyTime()
    {
        return instance.DishMuddyTime;
    }
    public static void SetPanel(GameObject Shop,GameObject End)
    {
        instance.ShopPanel = Shop;
        instance.EndPanel = End;
    }
}
