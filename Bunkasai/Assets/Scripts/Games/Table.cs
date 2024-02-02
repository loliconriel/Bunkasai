using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(click);
    }
    public void click()
    {
        if(transform.childCount > 0)
        {
            if (CustomerOrder.Compare(transform.GetChild(0).gameObject))
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            
        }
        
    }
    public void DoubleClick()
    {
        if(transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
