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
    public bool GamePause;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        RemainTime = TotalTime;
        //if (SceneManager.GetActiveScene().name == GamingScene.name) GamePause = true;
        //else GamePause = false;
        GamePause = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (GamePause)
        {
            if (RemainTime > 0)
            {
                RemainTime -= Time.deltaTime;
            }
        }
        
    }
    public static void Init()
    {
        instance.RemainTime = instance.TotalTime;


    }
    public static float GetRemainTime()
    {
        return instance.RemainTime/instance.TotalTime;
    }
    public static void GameState()
    {
        instance.GamePause = !instance.GamePause;
    }
}
