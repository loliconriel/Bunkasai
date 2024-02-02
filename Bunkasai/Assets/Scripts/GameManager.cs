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
    
    private int CurrentRound = 0;
    private int TotalRound = 1;
    private int TargetMoney = 1000;
    private float CustomerVisitSpeed = 1f;
    private float CustomerPassionate = 1f;
    private float PayAmount = 1f;
    private float CustomerSpeed = 1f;
    private float DishCookTime = 1f;
    private float DishMuddyTime = 1f;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        RemainTime = TotalTime;
        GameSet();
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
                PauseGame();
            }
        }
        
    }
    public static void GameSetting(int Difficulty)
    {

        switch (Difficulty)
        {
            case 0:
                GameSet(1, 1000, 1.5f, 1f, 1.5f, 1.2f, 0.5f, 1.5f);
                break;
            case 1:
                GameSet(1, 1000, 1.5f, 1f, 1.5f, 1.2f, 0.5f, 1.5f);
                break;
            case 2:
                GameSet(3, 4000, 1f, 1f, 1f, 1f, 1f, 1f);
                break;
            case 3:
                GameSet(6, 10000, 0.8f, 1.3f, 0.8f, 0.8f, 1.2f, 0.8f);
                break;
            case 4:
                GameSet(6, 10000, 0.8f, 1.3f, 0.8f, 0.8f, 1.2f, 0.8f);
                break;
        }
    }
    private static void GameSet(int TotalRound = 1,int TargetMoney = 1000,float CustomerPassionate = 1.5f,float CustomerVisitSpeed = 1f, float PayAmount = 1.5f,float CustomerSpeed = 1.2f,float DishCookTime = 0.5f,float DishMuddyTime = 1.5f)
    {
        instance.CurrentRound = 0; 
        instance.TotalRound = TotalRound;
        instance.TargetMoney = TargetMoney;
        instance.CustomerPassionate = CustomerPassionate;
        instance.CustomerVisitSpeed = CustomerVisitSpeed;
        instance.PayAmount = PayAmount;
        instance.CustomerSpeed = CustomerSpeed;
        instance.DishCookTime = DishCookTime;
        instance.DishMuddyTime = DishMuddyTime;
    }
    public static void GameInit(float TotalTime)
    {
        instance.TotalTime = TotalTime;
    }
    public static void Init()
    {
        instance.RemainTime = instance.TotalTime;
    }
    public static float GetRemainTime()
    {
        return instance.RemainTime/instance.TotalTime;
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
}
