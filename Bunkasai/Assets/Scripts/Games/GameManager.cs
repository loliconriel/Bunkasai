using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    [SerializeField]
    private SceneAsset GamingScene;
    [SerializeField]
    private float TotalTime;
    private float RemainTime;
    public bool GamePlayCheck;
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

    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlayCheck)
        {
            if (RemainTime > 0)
            {
                RemainTime -= Time.deltaTime;
            }
        }
        
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
    public static void PauseGame()
    {
        instance.GamePlayCheck = false;
    }
    public static void StartGame()
    {
        instance.GamePlayCheck = true;
    }
}
