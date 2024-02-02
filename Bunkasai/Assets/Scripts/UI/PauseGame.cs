using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    void Pause()
    {
        GameManager.PauseGame();
    }

    void Restart()
    {
        GameManager.StartGame();
    }
}
