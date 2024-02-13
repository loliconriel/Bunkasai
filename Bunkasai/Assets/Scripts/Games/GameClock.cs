using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClock : MonoBehaviour
{
    Slider slider;
    
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {

        slider.value = GameManager.GetRemainTime();
        
        
    }
}
