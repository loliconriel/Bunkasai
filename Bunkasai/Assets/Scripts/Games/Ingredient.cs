using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    protected GameObject Content;
    [SerializeField]
    protected GameObject FinalContent;
    [SerializeField]
    private GameObject TargetList;
    [SerializeField]
    protected GameObject FinalList;

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
            if (item.childCount <= 1)
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
