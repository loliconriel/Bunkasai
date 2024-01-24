using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClock : MonoBehaviour
{
    
    void Update()
    {
        GetComponent<Slider>().value = GameManager.GetRemainTime();
    }
}
