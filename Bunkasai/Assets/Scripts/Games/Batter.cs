using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batter : Ingredient
{
    [SerializeField]
    private float CookTime = 10f;
    [SerializeField]
    private float MuddyTime = 10f;
    protected override void action()
    {
        base.action();
        if(FindCheck) TargetCook.GetComponent<Cooker>().SetDish(CookTime, MuddyTime,FinalContent,FinalList);

    }
}
