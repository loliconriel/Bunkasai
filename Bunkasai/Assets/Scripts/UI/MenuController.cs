using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameType
{
    Directly,
    Customize
}
public class MenuController : MonoBehaviour
{
    [Header("Start Game Type")]
    [Tooltip("Directly:Start Game directly.\n Customize: Customize Game and then start game")]
    
    public GameType gameType;
    
    [SerializeField]
    Button StartButton;
    [SerializeField]
    GameObject CustomizePanel;
    [SerializeField]
    Button CustomizeButton;
    [Header("Menu Button")]
    [SerializeField]
    Button SettingButton;
    [SerializeField]
    Button QuitButton;
    [Space]
    [SerializeField]
    [Tooltip("Put the scene that you want to switch to")]
    SceneAsset GamingScene;
    [Space]
    [SerializeField]
    [Tooltip("Place the gamesetting panel in here")]
    GameObject SettingPanel;

    private void Awake()
    {
        if(gameType == GameType.Directly)
        {
            if (StartButton != null) StartButton.onClick.AddListener(StartGame);
            else Debug.LogWarning("The StartButton didn't assign");
        }
        else
        {
            if (StartButton != null) StartButton.onClick.AddListener(GameCustomize);
            else Debug.LogWarning("The StartButton didn't assign");
            if (CustomizeButton!=null) CustomizeButton.onClick.AddListener(StartGame);
        }
        
        if (SettingButton != null) SettingButton.onClick.AddListener(Setting);
        if (QuitButton != null) QuitButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        if (GamingScene != null) SceneManager.LoadScene(GamingScene.name);
        else Debug.LogWarning(this.name + ": GamingScene didn't assign.");
    }
    void GameCustomize()
    {
        if (CustomizePanel != null) CustomizePanel.SetActive(true);
    }
    void Setting()
    {
        if (SettingPanel != null) SettingPanel.SetActive(true);
    }
    void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
