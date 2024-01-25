using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerTrigger : MonoBehaviour
{
    [SerializeField]
    SceneAsset PlayScene;
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == PlayScene.name)
        {
            GameManager.Init();
            GameManager.StartGame();
        }
        else
        {
            GameManager.PauseGame();
        }

        Destroy(gameObject);
    }
}
