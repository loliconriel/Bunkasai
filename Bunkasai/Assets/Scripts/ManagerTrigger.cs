using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerTrigger : MonoBehaviour
{
    [SerializeField]
    string PlayScene;
    [SerializeField]
    GameObject ShopPanel;
    [SerializeField]
    GameObject EndPanel;
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == PlayScene)
        {
            GameManager.Init();
            GameManager.SetShopePanel(ShopPanel);
            GameManager.StartGame();
        }
        else
        {
            GameManager.PauseGame();
        }

        Destroy(gameObject);
    }
}
