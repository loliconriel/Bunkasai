using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waffle : Ingredient
{
    protected override void action()
    {
        if(transform.childCount != 0)
        {
            if(transform.GetChild(0).gameObject == Content)
            {
                
            }
        }
    }
}
