using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    private GameObject Content;
    [SerializeField]
    private GameObject TargetList;
    [SerializeField]
    private Button ActionButton;

    private void Awake()
    {
        if (ActionButton != null) ActionButton.onClick.AddListener(action);
    }

    protected virtual void action()
    {
        foreach (Transform item in TargetList.transform)
        {
            if (item.childCount == 0)
            {
                Instantiate(Content, item.transform);
                break;
            }
        }
    }
}
