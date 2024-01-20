using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    SceneAsset TargetScene;
    [SerializeField]
    Button ActionButton;
    private void Awake()
    {
        ActionButton.onClick.AddListener(Change);
    }
    void Change()
    {
        SceneManager.LoadScene(TargetScene.name);
    }
}
