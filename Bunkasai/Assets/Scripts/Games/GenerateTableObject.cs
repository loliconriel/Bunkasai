using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTableObject : MonoBehaviour
{
    [SerializeField]
    GameObject[] Content;
    [SerializeField]
    GameObject TargetList;
    [SerializeField]
    int Upgradeindex;
    [SerializeField]
    [Tooltip("1 is Row 0 is column")]
    int RowOrColumn = 0;
    [SerializeField]
    int ZeroAmount = 0;
    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        foreach (Transform game in transform)
        {
            Destroy(game.gameObject);
        }
        GameObject NewObject;
        for (int i = 0; i < GameManager.GetUpgrade(Upgradeindex) + ZeroAmount; i++)
        {
            
            NewObject = Instantiate(Content[i], transform);
            if (RowOrColumn == 0)
            {
                NewObject.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, (float)i / Content.Length);
                NewObject.GetComponent<RectTransform>().anchorMax = new Vector2(0.9f, (float)(i + 1) / Content.Length);
            }
            else
            {
                NewObject.GetComponent<RectTransform>().anchorMin = new Vector2((float)i / Content.Length, 0.1f);
                NewObject.GetComponent<RectTransform>().anchorMax = new Vector2((float)(i + 1) / Content.Length, 0.9f);
            }
            if(TargetList != null)
            {
                NewObject.GetComponent<Topping>().SetTargetList(TargetList);
            }
        }
    }
}
