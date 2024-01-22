using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    protected GameObject Content;
    [SerializeField]
    private GameObject TargetList;
    [SerializeField]
    private GameObject FinalList;

    protected GameObject TargetCook;
    protected bool FindCheck;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(action);
    }

    protected virtual void action()
    {
        foreach (Transform item in TargetList.transform)
        {
            if (item.childCount == 0)
            {
                Instantiate(Content, item.transform);
                TargetCook = item.gameObject;
                FindCheck = true;
                break;
            }
            else FindCheck = false;
        }
    }
}
