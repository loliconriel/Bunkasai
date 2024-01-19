using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Menu Button")]
    [SerializeField]
    Button StartButton;
    [SerializeField]
    Button SettingButton;
    [SerializeField]
    Button QuitButton;
    [Space]
    [SerializeField]
    [Tooltip("Put the scene that you want to switch to")]
    SceneAsset StartScene;
    [Space]
    [SerializeField]
    [Tooltip("Place the gamesetting panel in here")]
    GameObject SettingPanel;

    private void Awake()
    {
        if (StartButton != null) StartButton.onClick.AddListener(StartGame);
        if (SettingButton != null) SettingButton.onClick.AddListener(Setting);
        if (QuitButton != null) QuitButton.onClick.AddListener(QuitGame);
    }
    void StartGame()
    {
        if (StartScene != null) SceneManager.LoadScene(StartScene.name);
    }
    void Setting()
    {
        if (SettingPanel != null) SettingPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        if (SettingPanel != null) SettingPanel.SetActive(false);
    }
    void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
