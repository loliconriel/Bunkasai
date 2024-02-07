using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRound : MonoBehaviour
{
    [SerializeField]
    string GamingScene;

    public void click()
    {
        GameManager.AddCurrentRound();
        SceneManager.LoadScene(GamingScene);
    }
}
